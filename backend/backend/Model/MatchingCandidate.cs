using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Model
{
    public class MatchingCandidate
    {

        public MatchingCandidate(Job job,List<CandidateScore> candidate)
        {
            this.job = job;
            this.candidates = candidate;
        }
        public Job job { get; set; }

        public List<CandidateScore> candidates { get; set; }
    }
}
