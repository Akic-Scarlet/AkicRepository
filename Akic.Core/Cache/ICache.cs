
using System;
namespace Akic.Core.Cache
{
    public interface ICache
    {
        /// <summary>
        /// get or set value associate with special key
        /// </summary>
        /// <typeparam name="T">type of Cache item</typeparam>
        /// <param name="key">et or set value associate with special key</param>
        /// <returns></returns>
        T Get<T>(string key);

        /// <summary>
        /// add key and object
        /// </summary>
        /// <param name="key">Key of cache item</param>
        /// <param name="data">Value of Cache item</param>
        /// <param name="timespan">Cache time is minutes</param>
        void Set(string key, object data, TimeSpan timeout);
        /// <summary>
        /// Get a value indicating whether the value associate with the specified key is cached
        /// </summary>
        /// <param name="key">Key of cache item</param>
        /// <returns>True if item already is in cache; otherwise false</returns>
        bool IsSet(string key);
        /// <summary>
        /// Remove the value with key of cache item 
        /// </summary>
        /// <param name="key"></param>
        void Remove(string key);
        /// <summary>
        /// Remove items by key
        /// </summary>
        /// <param name="pattern"></param>
        void RemovePattern(string pattern);
        /// <summary>
        /// clear all cache data
        /// </summary>
        void clear();
    }
}
