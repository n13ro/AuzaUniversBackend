
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
        public static IServiceCollection AddRabbitMQ(this IServiceCollection services)
        {
            var options = new RabbitMQOptions();

            services.AddSingleton(options);
            services.AddSingleton<RabbitMQConnectionManager>();
            services.AddHostedService(sp => sp.GetRequiredService<RabbitMQConnectionManager>());

            services.AddSingleton<IRabbitMQService, RabbitMQService>();

            return services;
        }
    }
}
