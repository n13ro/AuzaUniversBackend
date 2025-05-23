using System.Collections.Concurrent;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Chat.Models;
using Microsoft.Extensions.Caching.Distributed;
using Chat.Protos;

namespace Chat.Services
{
    public class ChatService : Protos.ChatService.ChatServiceBase
    {
        private readonly ILogger<ChatService> _logger;
        private readonly IDistributedCache _cache;

        // Хранение активных соединений (userId -> stream)
        private static readonly ConcurrentDictionary<string, IServerStreamWriter<ChatMessage>> _connections =
            new ConcurrentDictionary<string, IServerStreamWriter<ChatMessage>>();

        // Хранение комнат (roomId -> ChatRoom)
        private static readonly ConcurrentDictionary<string, ChatRoom> _rooms =
            new ConcurrentDictionary<string, ChatRoom>();

        // Хранение пользователей (userId -> userName)
        private static readonly ConcurrentDictionary<string, ChatUser> _users =
            new ConcurrentDictionary<string, ChatUser>();

        public ChatService(ILogger<ChatService> logger, IDistributedCache cache)
        {
            _logger = logger;
            _cache = cache;
        }

        public override async Task Connect(
            IAsyncStreamReader<ChatMessage> requestStream,
            IServerStreamWriter<ChatMessage> responseStream,
            ServerCallContext context)
        {
            string? userId = null;
            string? roomId = null;
            string? userName = null; // Добавлено объявление переменной

            // Обработка входящих сообщений
            try
            {
                // Ожидаем первое сообщение (JOIN) для идентификации пользователя
                if (await requestStream.MoveNext())
                {
                    var connectMessage = requestStream.Current;

                    if (connectMessage.Type != ChatMessage.Types.MessageType.Join)
                    {
                        await responseStream.WriteAsync(new ChatMessage
                        {
                            Content = "Первое сообщение должно быть JOIN",
                            Type = ChatMessage.Types.MessageType.System,
                            Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
                        });
                        return;
                    }

                    userId = connectMessage.UserId;
                    userName = connectMessage.UserName; // Исправлено использование переменной
                    roomId = connectMessage.RoomId;

                    if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(roomId))
                    {
                        await responseStream.WriteAsync(new ChatMessage
                        {
                            Content = "Неверный формат JOIN сообщения",
                            Type = ChatMessage.Types.MessageType.System,
                            Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
                        });
                        return;
                    }

                    // Регистрируем пользователя
                    _users[userId] = new ChatUser(userId, userName);

                    // Добавляем пользователя в комнату или создаем новую
                    if (!_rooms.TryGetValue(roomId, out var room))
                    {
                        room = new ChatRoom
                        {
                            RoomId = roomId,
                            Name = $"Room {roomId}",
                            CreatorId = userId
                        };
                        _rooms[roomId] = room;
                    }

                    // Добавляем пользователя в комнату если он еще не там
                    if (!room.Users.Contains(userId))
                    {
                        room.Users.Add(userId);
                    }

                    // Сохраняем поток для отправки сообщений этому пользователю
                    _connections[userId] = responseStream;

                    // Отправляем системное сообщение о подключении пользователя всем участникам комнаты
                    var joinMessage = new ChatMessage
                    {
                        UserId = userId,
                        UserName = userName,
                        Content = $"{userName} присоединился к чату",
                        RoomId = roomId,
                        Type = ChatMessage.Types.MessageType.Join,
                        Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
                    };

                    await BroadcastMessageToRoom(joinMessage, roomId);

                    // Обработка последующих сообщений
                    while (await requestStream.MoveNext())
                    {
                        var message = requestStream.Current;
                        message.Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

                        // Проверяем, что сообщение от того же пользователя
                        if (message.UserId != userId)
                        {
                            continue;
                        }

                        // Обработка сообщения LEAVE
                        if (message.Type == ChatMessage.Types.MessageType.Leave)
                        {
                            await HandleUserLeave(userId, roomId);
                            break;
                        }

                        // Отправляем сообщение всем в комнате
                        await BroadcastMessageToRoom(message, roomId);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при обработке соединения");
            }
            finally
            {
                // Если пользователь был идентифицирован, обрабатываем его уход
                if (!string.IsNullOrEmpty(userId) && !string.IsNullOrEmpty(roomId))
                {
                    await HandleUserLeave(userId, roomId);
                }
            }
        }

        public override async Task<SendResponse> SendMessage(ChatMessage request, ServerCallContext context)
        {
            try
            {
                if (string.IsNullOrEmpty(request.UserId) || string.IsNullOrEmpty(request.RoomId))
                {
                    return new SendResponse
                    {
                        Success = false,
                        Error = "Отсутствует ID пользователя или комнаты",
                        Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
                    };
                }

                // Проверяем существование комнаты
                if (!_rooms.TryGetValue(request.RoomId, out var room))
                {
                    return new SendResponse
                    {
                        Success = false,
                        Error = "Комната не существует",
                        Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
                    };
                }

                // Проверяем, что пользователь в комнате
                if (!room.Users.Contains(request.UserId))
                {
                    return new SendResponse
                    {
                        Success = false,
                        Error = "Пользователь не в комнате",
                        Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
                    };
                }

                // Устанавливаем timestamp и отправляем сообщение
                request.Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                await BroadcastMessageToRoom(request, request.RoomId);

                return new SendResponse
                {
                    Success = true,
                    Timestamp = request.Timestamp
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при отправке сообщения");
                return new SendResponse
                {
                    Success = false,
                    Error = "Внутренняя ошибка сервера: " + ex.Message,
                    Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
                };
            }
        }

        private async Task BroadcastMessageToRoom(ChatMessage message, string roomId)
        {
            if (!_rooms.TryGetValue(roomId, out var room))
            {
                return;
            }

            var failedUsers = new List<string>();

            foreach (var userId in room.Users)
            {
                if (_connections.TryGetValue(userId, out var stream))
                {
                    try
                    {
                        await stream.WriteAsync(message);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, $"Ошибка при отправке сообщения пользователю {userId}");
                        failedUsers.Add(userId);
                    }
                }
                else
                {
                    // Пользователь не на связи, удаляем его из комнаты
                    failedUsers.Add(userId);
                }
            }

            // Удаляем пользователей, которым не удалось отправить сообщение
            foreach (var userId in failedUsers)
            {
                await HandleUserLeave(userId, roomId);
            }
        }

        private async Task HandleUserLeave(string userId, string roomId)
        {
            // Удаляем соединение
            _connections.TryRemove(userId, out _);

            if (_rooms.TryGetValue(roomId, out var room))
            {
                // Удаляем пользователя из комнаты
                room.Users.Remove(userId);

                // Если комната пуста и это не системная комната, удаляем её
                if (room.Users.Count == 0)
                {
                    _rooms.TryRemove(roomId, out _);
                }
                else
                {
                    // Оповещаем остальных пользователей
                    if (_users.TryGetValue(userId, out var user))
                    {
                        var leaveMessage = new ChatMessage
                        {
                            UserId = userId,
                            UserName = user.UserName,
                            Content = $"{user.UserName} покинул чат",
                            RoomId = roomId,
                            Type = ChatMessage.Types.MessageType.Leave,
                            Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
                        };

                        await BroadcastMessageToRoom(leaveMessage, roomId);
                    }
                }
            }

            // Если пользователь не участвует ни в одной комнате, удаляем информацию о нем
            bool userInAnyRoom = false;
            foreach (var r in _rooms.Values)
            {
                if (r.Users.Contains(userId))
                {
                    userInAnyRoom = true;
                    break;
                }
            }

            if (!userInAnyRoom)
            {
                _users.TryRemove(userId, out _);
            }
        }
    }
}