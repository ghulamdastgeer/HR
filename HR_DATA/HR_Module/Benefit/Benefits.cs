using System.Collections.Generic;
using static HR_DATA.HR_Module.DataUtils;

namespace HR_DATA.HR_Module.Benefit
{
    public class Benefits: HalfAuditEntity<int>
    {
        public string Benefit { get; set; }

        public BenefitType Type { get; set; }

        public List<EmployeeBenefits> Employees { get; set; }      
    }
}

