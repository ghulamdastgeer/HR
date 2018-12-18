using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HR.API.Controllers.Resources
{
    public class EmployeeDesignationResource
    {
        [Required]
        public string Name { get; set; }


    }
}
