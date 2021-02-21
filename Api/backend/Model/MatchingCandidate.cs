using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Model
{
    public class MatchingCandidate
    {

        public MatchingCandidate(Job Job,List<CandidateMatch> CandidateMatches)
        {
            this.Job = Job;
            this.CandidateMatches = CandidateMatches;
        }
        public Job Job { get; set; }

        public List<CandidateMatch> CandidateMatches { get; set; }
    }
}
