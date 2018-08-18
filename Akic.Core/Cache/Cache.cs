using System;
using System.Runtime.Caching;
namespace Akic.Core.Cache
{
    public class Cache:ICache
    {
        public T Get<T>(string key)
        {
            return (T)MemoryCache.Default.Get(key);
        }

        public void Set(string key, object data, TimeSpan timeout)
        {
            MemoryCache.Default.Add(key, data, new CacheItemPolicy { SlidingExpiration = timeout });
        }

        public bool IsSet(string key)
        {
            return MemoryCache.Default.Contains(key);
        }

        public void Remove(string key)
        {
            MemoryCache.Default.Remove(key);
        }

        public void RemovePattern(string pattern)
        {
             
        }

        public void clear()
        {
            foreach (var item in MemoryCache.Default)
                this.Remove(item.Key);
            
        }
    }
}
