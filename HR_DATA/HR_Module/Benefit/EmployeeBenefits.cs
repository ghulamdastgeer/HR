using HR_DATA.HR_Module.Organization;
using System;

namespace HR_DATA.HR_Module.Benefit
{
    public class EmployeeBenefits
    {
        public EmployeeBenefits()
        {
            CreationTime =  DateTime.Now;
        }
       
        public DateTime CreationTime { get; set; }

        public int EmployeeId{ get; set; }
        public Employee Employee { get; set; }
        public Benefits Benefits { get; set; } 
        public int BenefitId { get; set; }

    }
}
