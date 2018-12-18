using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static HR_DATA.HR_Module.DataUtils;

namespace HR.API.Controllers.Resources
{
    public class AttendanceResource
    {
        public DayOfWeek Day { get; set; }

        public AttendanceType Status { get; set; }
        [Required]
        public DateTime Check_in_time { get; set; }

        [Required]
        public DateTime Check_out_time { get; set; }

        public string Remarks { get; set; }

     
        public int EmployeeId { get; set; }
         

    }
}
