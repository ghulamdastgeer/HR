using System.ComponentModel.DataAnnotations;
using static HR_DATA.HR_Module.DataUtils;

namespace HR.API.Controllers.Resources
{
    public class SaveAddressResource
    {

        [Required]
        public string StreetAddress { get; set; }

        public AddressType AddressTypes { get; set; }

        public int CityId { get; set; } 
       
        //public int EmployeesId { get; set; }

        //public int BranchesId { get; set; }
    }
}
