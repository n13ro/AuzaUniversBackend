using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{
    public static class Extensions
    {
        public static IServiceCollection AddChatSignalRLogic(this IServiceCollection services)
        {
            services.AddSignalR();
            services.AddStackExchangeRedisCache(o =>
            {
                var conn = "localhost:6379";
                var conn2 = "127.0.0.1:6379";
                o.Configuration = conn2;
            });

            return services;
        }
    }
}
