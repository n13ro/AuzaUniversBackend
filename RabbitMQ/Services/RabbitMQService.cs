
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace RabbitMQ.Services
{
    public class RabbitMQService : IRabbitMQService
    {
        private readonly RabbitMQConnectionManager _manager;

        public RabbitMQService(RabbitMQConnectionManager manager)
        {
            _manager = manager;
        }

        public async Task PublishMessage(string msg, string key)
        {
            var body = Encoding.UTF8.GetBytes(msg);
            await _manager.Channel.BasicPublishAsync(
                "",
                key,
                body
                );
        }

        public async Task Subscribe(string queueName, Func<string, Task> handler)
        {
            await _manager.Channel.QueueDeclareAsync(
                queueName,
                false,
                false,
                false,
                null
                );

            var consumer = new AsyncEventingBasicConsumer(_manager.Channel);
            consumer.ReceivedAsync += async (_, ea) =>
            {
                var body = ea.Body.ToArray();
                var mess = Encoding.UTF8.GetString(body);
                try
                {
                    await handler(mess);
                    await _manager.Channel.BasicAckAsync(ea.DeliveryTag, false);
                }
                catch(Exception ex)
                {
                    await _manager.Channel.BasicNackAsync(ea.DeliveryTag, false, true);
                }
            };
            await _manager.Channel.BasicConsumeAsync(
                queueName,
                false,
                consumer
                );

        }
        public void Dispose()
        {
            _manager.Channel?.Dispose();
            _manager.Connection?.Dispose();
        }
    }
}
