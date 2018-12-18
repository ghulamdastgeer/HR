using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static HR_DATA.HR_Module.DataUtils;

namespace HR.API.Controllers.Resources
{
    public class SaveEmployeeResource
    {
        public SaveEmployeeResource()
        {
            Address = new SaveAddressResource ();
            EmployeeDesignation = new EmployeeDesignationResource();
            Salary = new SalaryResource();
            Benefits = new List<EmployeeBenefitResource>();
            EmployeeImageResource = new List<EmployeeImageResource>();
        }
        public string Name { get; set; }

        public string PhoneNo { get; set; }


        public DateTime DOB { get; set; }

        public Gender Gender { get; set; }

        
        public EmployeeDesignationResource EmployeeDesignation { get; set; }
  
        public SalaryResource Salary { get; set; }

        public List<EmployeeBenefitResource> Benefits { get; set; }

        public int UserId { get; set; }
        
        public int DepartmentId { get; set; }
      
        public SaveAddressResource Address { get; set; }

        public List<EmployeeImageResource> EmployeeImageResource { get; set; }
    }
}
