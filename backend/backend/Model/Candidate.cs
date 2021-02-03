using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Model
{
    public class Candidate
    {
        public int id { get; set; }

        [Required]
        public string candidatename { get; set; }

        [Required]
        public string skills { get; set; }
    }
}
