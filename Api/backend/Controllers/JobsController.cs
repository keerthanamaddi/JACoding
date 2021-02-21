using System;
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

namespace Api.Controllers
{
    [Route("jobs")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private IJob _jobService;
        
        public JobsController(IJob data)
        {
            _jobService = data;
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



    }
}
