using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Model;

namespace Api.Service
{
    public interface ICandidate
    {
        List<Candidate> GetAllCandidates();
    }
}
