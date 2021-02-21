using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Model;

namespace Api.Service
{
    public interface IJob
    {
        List<Job> GetAllJobs();

        Job GetJob(int id);

        Job AddJob(Job jobDetails);

    }
}
