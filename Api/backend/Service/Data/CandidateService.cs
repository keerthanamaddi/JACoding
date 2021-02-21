using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Model;
using Api.Model.Context;

namespace Api.Service.Data
{
    public class CandidateService : ICandidate
    {
        JobAdderDemoContext _candidateContext;
        public CandidateService(JobAdderDemoContext context)
        {
            _candidateContext = context;
        }

        public List<Candidate> GetAllCandidates()
        {
            return _candidateContext.Candidates.ToList();
        }
    }
}
