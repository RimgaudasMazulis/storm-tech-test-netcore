using System.Runtime.Caching;
using System;
using Todo.Interfaces.Cache;

namespace Todo.Cache
{
    public class Cache : ICache
    {
        private static readonly ObjectCache cache = MemoryCache.Default;
        private static readonly object lockObject = new object();

        public T Get<T>(string key)
        {
            lock (lockObject)
            {
                if (cache.Contains(key))
                {
                    return (T)cache[key];
                }
                return default(T);
            }
        }

        public void Set<T>(string key, T value, TimeSpan expiration)
        {
            lock (lockObject)
            {
                cache.Set(key, value, DateTime.Now.Add(expiration));
            }
        }

        public void Remove(string key)
        {
            lock (lockObject)
            {
                cache.Remove(key);
            }
        }
    }
}
