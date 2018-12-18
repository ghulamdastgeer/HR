using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HR.API.Controllers.Resources
{
    public class JobPostingResource
    {
        [Required]
        public string JobTitle { get; set; }


        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        public string ImagUrl { get; set; }

        public int Vaccancies { get; set; }

    }
}
