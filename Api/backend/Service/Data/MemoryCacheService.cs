using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Api.Model;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;

namespace Api.Service.Data
{
    public class MemoryCacheService
    {

        private readonly IMemoryCache _memoryCache;
        private MemoryCacheEntryOptions cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(5));

        public List<MatchingCandidate> GetCacheValue(string key)
        {
            if (_memoryCache.TryGetValue(key, out List<MatchingCandidate> cacheValue))
            {
                return cacheValue;
            }

            return null;
        }

        public void Set(string _key, List<MatchingCandidate> value)
        {
            _memoryCache.Set(_key, value, cacheEntryOptions);

        }

        public MemoryCacheService(IMemoryCache memoryCache)
        {
            this._memoryCache = memoryCache;
        }
    }
}
