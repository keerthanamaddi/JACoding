using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Model;

namespace backend.Service
{
    public interface ICandidate
    {
        List<Candidate> GetAllCandidates();
    }
}
