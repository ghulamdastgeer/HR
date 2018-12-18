using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.API.Controllers.Resources
{
    public class EmployeeResource
    {
        public EmployeeResource()
        {
            Address = new AddressResource();
            EmployeeDesignation = new EmployeeDesignationResource();
            Salary = new SalaryResource();
            Benefits = new List<EmployeeBenefitResource>();
            EmployeeImageResource = new List<EmployeeImageResource>();
            DepartmentResource =new DepartmentsResource();
        }
        public int Id{get;set;}
        public string Name { get; set; }
        public string PhoneNo { get; set; }

        public int PaidTimeOff { get; set; }

        public DateTime DOB { get; set; }

        public string Gender { get; set; }
        
        public EmployeeDesignationResource EmployeeDesignation { get; set; }
        
        public SalaryResource Salary { get; set; }
       
        public List<EmployeeBenefitResource> Benefits { get; set; }
        
        public int UserId { get; set; }

        public DepartmentsResource DepartmentResource { get; set; }
  
        public AddressResource Address { get; set; }

        public List<EmployeeImageResource> EmployeeImageResource { get; set; }

    }
}
