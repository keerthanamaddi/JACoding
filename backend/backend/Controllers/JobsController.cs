using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace backend.Controllers
{
    [Route("jobs")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public JobsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]

        public JsonResult Get()
        {
            string query = @"select id as jobId,jobname as name,company,skills from dbo.Jobs";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("JobadderAppCon");
            SqlDataReader myReader;
            using(SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using(SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult Post(Model.Jobs job)
        {
            string query = @"insert into dbo.Jobs values ('" + job.jobname + "','" + job.skills + @"')";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("JobadderAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }

    }
}
