using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using backend.Service;

namespace backend.Controllers
{
    [Route("jobs")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private IJob _jobData;
        
        public JobsController(IJob data)
        {
            _jobData = data;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_jobData.GetAllJobs());
        }

        //get job by ID
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var job = _jobData.GetJob(id);

            if (job != null)
            {
                //200 response
                return Ok(job);
            }

            //return 404
            return NotFound($"Job with id {id} not found");
        }



    }
}
