using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Model;
using backend.Service.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace backend.Controllers
{
    [Route("matchingcandidates")]
    [ApiController]
    public class MatchingCandidatesController : ControllerBase
    {
        private readonly MatchingCandidatesData _matchingCandidatesData;
        private readonly ILogger<MatchingCandidatesController> _logger;

        public MatchingCandidatesController(ILogger<MatchingCandidatesController> logger, MatchingCandidatesData matchingcandidates)
        {
            _matchingCandidatesData = matchingcandidates;
            _logger = logger;
        }

        [HttpGet]
        public async Task<List<MatchingCandidate>> Get()
        {
            return await _matchingCandidatesData.GetMatchingCandidates();
        }
    }
}
