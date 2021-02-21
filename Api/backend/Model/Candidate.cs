using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Model
{
    public class Candidate
    {
        public int CandidateId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string SkillTags { get; set; }
    }
}
