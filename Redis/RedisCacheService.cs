using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Redis
{
    public class RedisCacheService
    {
        private readonly IDistributedCache _cache;

        public RedisCacheService(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<T> GetOrCreateCacheAsync<T>(string key, Func<Task<T>> action, TimeSpan? time = null)
        {
            var cacheData = await _cache.GetAsync(key);

            if (cacheData != null)
            {
                return JsonSerializer.Deserialize<T>(cacheData);
            }
            var data = await action();

            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = time ?? TimeSpan.FromMinutes(10)
            };

            await _cache.SetStringAsync(key, JsonSerializer.Serialize(data), options);

            return data;
        }

        public async Task RemoveCacheAsync(string key)
        {
            await _cache.RemoveAsync(key);
        }
    }
}
