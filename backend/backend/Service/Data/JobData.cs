using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Model;
using backend.Model.Context;

namespace backend.Service.Data
{
    public class JobData : IJob
    {
        JobContext _jobContext;
        public JobData(JobContext context)
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
