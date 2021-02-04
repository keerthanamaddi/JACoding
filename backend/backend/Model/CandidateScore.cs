using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Model
{
    public class CandidateScore

    {
        public CandidateScore(Candidate candidate, int score)
        {
            this.candidate = candidate;
            this.score = score;
        }
        public Candidate candidate { get; set; }

        public int score { get; set; }
    }
}
