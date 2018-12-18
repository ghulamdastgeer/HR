using HR_DATA.HR_Module.Organization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.API.Controllers.Resources
{
    public class EmployeePerformanceResource
    {
        public EmployeePerformanceResource()
        {
            Performance = new PerformanceResource();
        }
        public float PerformacePercentage { get; set; }

        public int EmployeeId { get; set; }
       
        public PerformanceResource Performance { get; set; }
    }

}
