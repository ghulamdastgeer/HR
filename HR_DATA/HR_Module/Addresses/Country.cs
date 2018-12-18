using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HR_DATA.HR_Module.Addresses
{
    public class Country:HalfAuditEntity<int>
    { 

        [Required]
        public string Name { get; set; }
        public int Code { get; set; }

    public List<City> Cities { get; set; }

        
    }
   
}
