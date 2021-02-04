using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Model;

namespace backend.Data
{
    public interface IJob
    {
        List<Job> GetAllJobs();

        Job GetJob(int id);

        Job AddJob(Job jobDetails);

    }
}
