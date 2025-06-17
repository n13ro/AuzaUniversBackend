using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;


namespace CustomMemoryCache
{
    public class InMemoryCacheService
    {
        private readonly IMemoryCache _cache;
        private readonly ILogger<InMemoryCacheService> _logger;

        public InMemoryCacheService(IMemoryCache cache, ILogger<InMemoryCacheService> logger)
        {
            _cache = cache;
            _logger = logger;
        }

        public async Task<T> GetOrCreateCacheAsync<T>(string key, Func<Task<T>> action)
        {
            if (_cache.TryGetValue(key, out var obj) && obj is T cacheValue)
            {
                _logger.LogInformation("Cache hit for key: {Key}", key);
                return cacheValue;
            }

            _logger.LogInformation("Cache miss for key: {Key}", key);
            var data = await action();

            var options = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10),
                SlidingExpiration = TimeSpan.FromMinutes(5)
            };

            _cache.Set(key, data, options);
            _logger.LogInformation("Cache set for key: {Key}", key);

            return data;
        }

        public Task RemoveCacheAsync(string key)
        {
            _cache.Remove(key);
            _logger.LogInformation("Cache removed for key: {Key}", key);
            return Task.CompletedTask;
        }
    }
}
