using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Model;
using Microsoft.EntityFrameworkCore;

namespace backend.Model.Context
{
    //entity framework db context
    public class JobContext : DbContext
    {
       
        public JobContext(DbContextOptions<JobContext> options) : base(options)
        {

        }

        public DbSet<Job> Jobs { get; set; }
    }
}
