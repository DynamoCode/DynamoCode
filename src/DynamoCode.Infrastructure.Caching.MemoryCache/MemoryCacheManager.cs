using DynamoCode.Infrastructure.Caching;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DynamoCode.Infrastructure.Caching.MemoryCache
{
    /// <summary>
    /// Represents a MemoryCacheCache
    /// </summary>
    public class MemoryCacheManager : ICacheManager
    {
        private IMemoryCache _cache;

        public MemoryCacheManager(IMemoryCache cache)
        {
            _cache = cache;
        }

        /// <summary>
        /// Gets or sets the value associated with the specified key.
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="key">The key of the value to get.</param>
        /// <returns>The value associated with the specified key.</returns>
        public T Get<T>(string key)
        {
            return _cache.Get<T>(key);
        }

        /// <summary>
        /// Adds the specified key and object to the cache.
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="data">Data</param>
        /// <param name="cacheTime">Cache time</param>
        public void Set(string key, object data, int cacheTime)
        {
            _cache.Set(key, data);
        }

        /// <summary>
        /// Gets a value indicating whether the value associated with the specified key is cached
        /// </summary>
        /// <param name="key">key</param>
        /// <returns>Result</returns>
        public bool IsSet(string key)
        {
            object _value;
            return _cache.TryGetValue(key, out _value);
        }

        /// <summary>
        /// Removes the value with the specified key from the cache
        /// </summary>
        /// <param name="key">/key</param>
        public void Remove(string key)
        {
            _cache.Remove(key);
        }

        /// <summary>
        /// Removes items by pattern
        /// </summary>
        /// <param name="pattern">pattern</param>
        public void RemoveByPattern(string pattern)
        {
            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = new List<String>();

            foreach (string key in keysToRemove)
            {
                Remove(key);
            }
        }
    }
}
