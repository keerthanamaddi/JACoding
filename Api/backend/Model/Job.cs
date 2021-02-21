using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Model
{
    public class Job
    {
        public int JobId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Skills { get; set; }

        [Required]
        public string Company { get; set; }


    }
}
