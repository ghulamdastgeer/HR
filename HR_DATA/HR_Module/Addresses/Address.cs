using HR_DATA.HR_Module.Organization;
using System.ComponentModel.DataAnnotations;
using static HR_DATA.HR_Module.DataUtils;

namespace HR_DATA.HR_Module.Addresses
{
    public class Address:HalfAuditEntity<int>
    {
        [Required]
        public string StreetAddress { get; set; }

        public  AddressType AddressTypes  { get;set; }

        public int CityId { get; set; }
        public  City City { get; set; }
      
        public int? BranchesId { get; set; }
        public Branch Branches { get; set; }

        public int? EmployeesId { get; set; }
        public Employee Employees { get; set; }
    }
}
