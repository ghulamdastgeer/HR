using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HR.API.Controllers.Resources
{
    
    public class SaveOrganizationResource
    {
        //   public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        
    }
}
