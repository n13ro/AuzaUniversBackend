using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.Services
{
    public class RabbitMQConnectionManager : IHostedService, IDisposable
    {
        private readonly RabbitMQOptions _options;
        public IConnection Connection { get; private set; }
        public IChannel Channel { get; private set; }

        public RabbitMQConnectionManager(RabbitMQOptions options)
        {
            _options = options;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var factory = new ConnectionFactory
            {
                HostName = _options.HostName,
                UserName = _options.UserName,
                Password = _options.Password,
                Port = _options.Port
            };

            // Асинхронно создаём соединение и канал
            Connection = await factory.CreateConnectionAsync();
            Channel = await Connection.CreateChannelAsync();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Channel?.Dispose();
            Connection?.Dispose();
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            Channel?.Dispose();
            Connection?.Dispose();
        }
    }
}
