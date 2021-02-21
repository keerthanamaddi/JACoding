using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Model
{
    public class CandidateMatch

    {
        public CandidateMatch(Candidate candidate, int score)
        {
            this.Candidate = candidate;
            this.MatchingScore = score;
        }
        public Candidate Candidate { get; set; }

        public int MatchingScore { get; set; }
    }
}
