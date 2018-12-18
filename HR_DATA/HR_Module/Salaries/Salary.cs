using HR_DATA.HR_Module.Organization;
using System;

namespace HR_DATA.HR_Module.Salaries
{
    public class Salary:HalfAuditEntity<int>
    {
        
         public float Salaries{get;set;}
          
      
          public int EmployeeId { get; set; }
          public Employee Employee { get; set; }


    }
}