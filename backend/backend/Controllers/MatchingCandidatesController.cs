using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Model;
using backend.Service.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace backend.Controllers
{
    [Route("matchingcandidates")]
    [ApiController]
    public class MatchingCandidatesController : ControllerBase
    {
        private readonly MatchingCandidatesData _matchingCandidatesData;
        private readonly ILogger<MatchingCandidatesController> _logger;
        private IMemoryCache _memoryCache;

        public MatchingCandidatesController(ILogger<MatchingCandidatesController> logger, MatchingCandidatesData matchingcandidates, IMemoryCache cache)
        {
            _matchingCandidatesData = matchingcandidates;
            _logger = logger;
            _memoryCache = cache;
        }

        [HttpGet]
        public async Task<List<MatchingCandidate>> Get()
        {
            //In memory caching
            List<MatchingCandidate> cacheEntry;
            if(!_memoryCache.TryGetValue("matchingCandidates", out cacheEntry))
            {
                cacheEntry = await _matchingCandidatesData.GetMatchingCandidates();

                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(5));

                _memoryCache.Set("matchingCandidates", cacheEntry, cacheEntryOptions);
            }
            return cacheEntry;
            //return await _matchingCandidatesData.GetMatchingCandidates();
        }
    }
}
