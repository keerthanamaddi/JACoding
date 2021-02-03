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
    [Route("candidates")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public CandidatesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]

        public JsonResult Get()
        {
            string query = @"select id as candidateId,candidatename as name,skills as skillTags from dbo.candidates";
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

        [HttpPost]
        public JsonResult Post(Model.Candidate candidate)
        {
            string query = @"insert into dbo.candidates values ('" + candidate.candidatename + "','" + candidate.skills + @"')";
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
