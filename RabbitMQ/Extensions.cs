
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using RabbitMQ.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ
{
    public static class Extensions
    {
        public static IServiceCollection AddRabbitMQ(this IServiceCollection services, Action<RabbitMQOptions> configure)
        {
            var options = new RabbitMQOptions();
            configure(options);

            services.AddSingleton(options);
            services.AddSingleton<RabbitMQConnectionManager>();
            services.AddHostedService(sp => sp.GetRequiredService<RabbitMQConnectionManager>());
            services.AddScoped<IRabbitMQService, RabbitMQService>();

            return services;
        }
    }
    public class RabbitMQOptions
    {
        public string HostName { get; set; } = "localhost";
        public string UserName { get; set; } = "rmuser";
        public string Password { get; set; } = "rmpassword";
        public int Port { get; set; } = 5672;
    }
}
