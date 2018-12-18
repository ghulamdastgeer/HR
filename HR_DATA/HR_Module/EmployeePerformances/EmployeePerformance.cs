using HR_DATA.HR_Module.Organization;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR_DATA.HR_Module.EmployeePerformances
{
    public class EmployeePerformance : HalfAuditEntity<int>
    {
        public float PerformacePercentage { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public Performance Performance { get; set; }
    }
}