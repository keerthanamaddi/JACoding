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

namespace Api.Controllers
{
    [Route("candidates")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        private readonly ICandidate _candidate;

        public CandidatesController(ICandidate candidate)
        {
            _candidate = candidate;
        }

        [HttpGet]

        public IActionResult Get()
        {
            return Ok(_candidate.GetAllCandidates());
        }



       
    }
}
