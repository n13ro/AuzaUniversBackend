
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
        private readonly Dictionary<string, string> _consumerTags = new();
        private readonly RabbitMQConnectionManager _manager;

        public RabbitMQService(RabbitMQConnectionManager manager)
        {
            _manager = manager;

        }

        public async Task PublishMessage(string msg, string key)
        {
            await _manager.Channel.QueueDeclareAsync(
                key,
                false,
                false,
                false,
                null
                );
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
            var tag = await _manager.Channel.BasicConsumeAsync(
                queueName,
                false,
                consumer
                );
            _consumerTags[queueName] = tag;

        }
        public async Task Unsubscribe(string queueName)
        {
            if(_consumerTags.TryGetValue(queueName, out var tag)) 
            {
                await _manager.Channel.BasicCancelAsync(tag);   
                _consumerTags.Remove(queueName);
            }
        }
        public void Dispose()
        {
            _manager.Channel?.Dispose();
            _manager.Connection?.Dispose();
        }

    }
}
