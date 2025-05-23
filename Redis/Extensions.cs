using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redis
{
    public static class Extensions
    {
        public static IServiceCollection AddRedis(this IServiceCollection services)
        {
            services.AddSingleton<RedisCacheService>();
            services.AddStackExchangeRedisCache(options => {
                options.Configuration = "127.0.0.1:6379";
            });

            return services;
        }
    }
}
