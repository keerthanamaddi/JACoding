﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using Api.Service;
using Api.Model;
using Microsoft.AspNetCore.Authorization;

namespace Api.Controllers
{
    [Authorize]
    [Route("jobs")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private IJob _jobService;
        private readonly ICustomAuthenticationManager _customAuthenticationManager;

        public JobsController(IJob data, ICustomAuthenticationManager customAuthenticationManager)
        {
            _jobService = data;
            _customAuthenticationManager = customAuthenticationManager;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_jobService.GetAllJobs());
        }

        //get job by ID
        [HttpGet]
        [Route("{jobId}")]
        public IActionResult Get(int jobId)
        {
            if(jobId <= 0)
            {
                return BadRequest("Job Id must be > 0");
            }

            Job job;
            try
            {
                job = _jobService.GetJob(jobId);

            }catch(Exception e)
            {
                return UnprocessableEntity();
            }
            
            if (job != null)
            {
                //200 response
                return Ok(job);
            }

            //return 404
            return NotFound($"Job with id {jobId} not found");
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] User user)
        {
            var token = _customAuthenticationManager.Authenticate(user.UserName, user.Password);

            if (token == null)
                return Unauthorized();

            return Ok(token);
        }



    }
}
