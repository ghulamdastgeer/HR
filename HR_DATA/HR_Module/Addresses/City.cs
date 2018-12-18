using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HR_DATA.HR_Module.Addresses
{
    public class City:HalfAuditEntity<int>
    {
        [Required]
        public string Name { get; set; }

        //many to one
        public int CountryId { get; set; }
        public  Country Country { get; set; }

        public List<Address> Addresses { get; set; }
    }
}
