using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Model
{
    public class Job
    {
        public int id { get; set; }

        [Required]
        public string jobname { get; set; }

        [Required]
        public string skills { get; set; }

        [Required]
        public string company { get; set; }


    }
}
