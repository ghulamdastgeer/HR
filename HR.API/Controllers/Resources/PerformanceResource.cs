using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static HR_DATA.HR_Module.DataUtils;

namespace HR.API.Controllers.Resources
{
    public class PerformanceResource
    {
       
        public int TaskCompleted { get; set; }

        public float Punctual { get; set; }


        public Behaviour Behaviour { get; set; }

//        public int EmployeePerformanceId { get; set; }
       
    }
}
