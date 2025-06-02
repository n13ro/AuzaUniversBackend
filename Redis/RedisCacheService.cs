using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Redis
{
    public class RedisCacheService
    {
        private readonly IDistributedCache _cache;

        public RedisCacheService(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<T> GetOrCreateCacheAsync<T>(string key, Func<Task<T>> action)
        {
            var cacheData = await _cache.GetAsync(key);

            if (cacheData != null)
            {
                return JsonSerializer.Deserialize<T>(cacheData);
            }
            var data = await action();

            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
            };

            await _cache.SetStringAsync(key, JsonSerializer.Serialize(data), options);

            return data;
        }

        public async Task RemoveCacheAsync(string key)
        {
            await _cache.RemoveAsync(key);
        }

        public async Task CreateCacheAsync<T>(string key, T data)
        {
            if (data != null)
            {
                var serelizeData = JsonSerializer.Serialize(data);
                var options = new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
                };
                await _cache.SetStringAsync(key, serelizeData, options);
            }
        }


    }
}
