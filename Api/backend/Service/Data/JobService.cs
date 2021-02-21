using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Model;
using Api.Model.Context;

namespace Api.Service.Data
{
    public class JobService : IJob
    {
        JobAdderDemoContext _jobContext;
        public JobService(JobAdderDemoContext context)
        {
            _jobContext = context;
        }

        public List<Job> GetAllJobs()
        {
            return _jobContext.Jobs.ToList();
        }

        public Job AddJob(Job jobDetails)
        {
            throw new NotImplementedException();
        }

        public Job GetJob(int id)
        {
            return _jobContext.Jobs.Find(id);
        }

       
    }
}
