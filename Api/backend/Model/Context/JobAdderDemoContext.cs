using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Model;
using Microsoft.EntityFrameworkCore;

namespace Api.Model.Context
{
    //entity framework db context
    public class JobAdderDemoContext : DbContext
    {
       
        public JobAdderDemoContext(DbContextOptions<JobAdderDemoContext> options) : base(options)
        {

        }

        public DbSet<Job> Jobs { get; set; }

        public DbSet<Candidate> Candidates { get; set; }
    }
}
