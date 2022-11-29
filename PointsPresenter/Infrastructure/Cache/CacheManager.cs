using Microsoft.Extensions.Caching.Memory;
using Model.Cache;

namespace Infrastructure.Cache
{
    public class CacheManager : ICacheManager
    {
        private readonly IMemoryCache _cache;
        private object _lock = new object();
        public CacheManager(IMemoryCache cache)
        {
            _cache = cache;
        }

        public List<T> GetData<T>(string key)
        {
            lock (_lock)
            {
                var isExist = _cache.TryGetValue(key, out List<T> existingItem);
                if (!isExist)
                {
                    return new List<T>();
                }

                return _cache.Get<List<T>>(key);
            }

        }

        public void Remove<T>(T item, string key)
        {
            var cache = GetData<T>(key);
            if (cache == null || !cache.Any())
                return;

            cache.Remove(item);
        }

        public void AddOrUpdate<T>(string key, T value)
        {
            lock (_lock)
            {
                var isExist = _cache.TryGetValue(key, out List<T> existingItem);
                if (!isExist)
                {
                    _cache.Set(key, new List<T> { value });
                    return;
                }

                var existingCache = _cache.Get<List<T>>(key);
                existingCache.Add(value);
                _cache.Remove(key);
                _cache.Set(key, existingCache);
            }
        }
    }
}
