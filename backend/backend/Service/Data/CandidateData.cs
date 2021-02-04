using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Model;
using backend.Model.Context;

namespace backend.Service.Data
{
    public class CandidateData : ICandidate
    {
        CandidateContext _candidateContext;
        public CandidateData(CandidateContext context)
        {
            _candidateContext = context;
        }

        public List<Candidate> GetAllCandidates()
        {
            return _candidateContext.Candidates.ToList();
        }
    }
}
