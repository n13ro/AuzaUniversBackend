using Microsoft.Extensions.DependencyInjection;

namespace MemoryCache
{
    public static class Extensions
    {
        public static IServiceCollection AddInMemoryCache(this IServiceCollection services)
        {
            //services.AddMemoryCache();
            services.AddSingleton<InMemoryCacheService>();
            return services;
        }
    }
}
