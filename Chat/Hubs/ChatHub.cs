using Chat.Modules;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Chat.Hubs
{
    public interface IChatClient
    {
        public Task ReceiveMessage(string userName, string message);
    }
    public class ChatHub : Hub<IChatClient>
    {
        private readonly IDistributedCache _cache;
        private readonly ILogger<ChatHub> _logger;

        public ChatHub(IDistributedCache cache, ILogger<ChatHub> logger)
        {
            _cache = cache;
            _logger = logger;
        }
        public async Task JoinChat(UserConnection connection)
        {
            _logger.LogInformation($"JoinChat called: userName={connection.userName}, chatRoom={connection.chatRoom}, connectionId={Context.ConnectionId}");
            await Groups.AddToGroupAsync(Context.ConnectionId, connection.chatRoom);

            var stringConn = JsonSerializer.Serialize(connection);
            await _cache.SetStringAsync(Context.ConnectionId, stringConn);

            await Clients.Group(connection.chatRoom).ReceiveMessage($"{connection.userName}, ", "присоеденился к чату");
        }

        public override async Task OnConnectedAsync()
        {
            _logger.LogInformation($"New connection: {Context.ConnectionId}");
            var httpContext = Context.GetHttpContext();
            var userName = httpContext.Request.Query["userName"].ToString();
            var chatRoom = httpContext.Request.Query["chatRoom"].ToString();

            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(chatRoom))
            {
                var connection = new UserConnection(userName, chatRoom);
                await JoinChat(connection);
            }

            await base.OnConnectedAsync();
        }

        public async Task SendMessage(string message)
        {
            _logger.LogInformation($"SendMessage called: message={message}, connectionId={Context.ConnectionId}");
            var stringConn = await _cache.GetAsync(Context.ConnectionId);

            var connection = JsonSerializer.Deserialize<UserConnection>(stringConn);

            if(connection is not null)
            {
                await Clients.Group(connection.chatRoom).ReceiveMessage(connection.userName, message);

            }
                
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            _logger.LogInformation($"Disconnected: {Context.ConnectionId}");
            var stringConn = await _cache.GetAsync(Context.ConnectionId);
            var connection = JsonSerializer.Deserialize<UserConnection>(stringConn);

            if (connection is not null)
            {
                await _cache.RemoveAsync(Context.ConnectionId);
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, connection.chatRoom);
                await Clients.Group(connection.chatRoom).ReceiveMessage($"{connection.userName}, ", "вышел из чата");
            }
            await base.OnDisconnectedAsync(exception);
        }
    }
}
