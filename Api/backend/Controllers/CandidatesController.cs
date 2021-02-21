using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using Api.Model;
using Api.Service;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
    [Route("candidates")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        private readonly ICandidate _candidate;
        private readonly ILogger<CandidatesController> _logger;

        public CandidatesController(ICandidate candidate, ILogger<CandidatesController> logger)
        {
            _candidate = candidate;
            _logger = logger;
        }

        [HttpGet]

        public IActionResult Get()
        {
            _logger.LogInformation("Get candidates list log");
            return Ok(_candidate.GetAllCandidates());
        }



       
    }
}
