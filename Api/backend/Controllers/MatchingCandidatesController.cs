using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Model;
using Api.Service.Data;
using Api.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
    [Route("matchingcandidates")]
    [ApiController]
    public class MatchingCandidatesController : ControllerBase
    {
        private readonly MatchingCandidatesService _matchingCandidatesData;
        private readonly ILogger<MatchingCandidatesController> _logger;
        private readonly MemoryCacheService _memoryCacheService;

        public MatchingCandidatesController(ILogger<MatchingCandidatesController> logger, MatchingCandidatesService matchingcandidates,MemoryCacheService memoryCacheService)
        {
            _matchingCandidatesData = matchingcandidates;
            _logger = logger;
            _memoryCacheService = memoryCacheService;
        }

        [HttpGet]
        public async Task<List<MatchingCandidate>> Get()
        {
            try
            {
                List<MatchingCandidate> cacheEntry = _memoryCacheService.GetCacheValue(CacheKeys.MatchingCandidates);
                if (cacheEntry == null)
                {
                    cacheEntry = await _matchingCandidatesData.GetMatchingCandidates() as List<MatchingCandidate>;

                    _memoryCacheService.Set(CacheKeys.MatchingCandidates, cacheEntry);
                }

                return cacheEntry;
            }catch(Exception e)
            {
                _logger.LogInformation("Error in retrieving the matching candidates list");
            }

            return null;
            //return await _matchingCandidatesData.GetMatchingCandidates();
        }
    }
}
