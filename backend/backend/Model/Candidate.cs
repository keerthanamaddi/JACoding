using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Model
{
    public class Candidate
    {
        public int candidateId { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string skillTags { get; set; }
    }
}
