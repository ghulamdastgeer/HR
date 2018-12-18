using HR_DATA.HR_Module.Organization;
using System;
using System.ComponentModel.DataAnnotations;
using static HR_DATA.HR_Module.DataUtils;

namespace HR_DATA.HR_Module.Attendance_Leave
{
    public class Attendance : HalfAuditEntity<int>
    {
        [Required]
        public DayOfWeek Day { get; set; }
        
        public AttendanceType Status {get;set;}
        [Required]
        public DateTime Check_in_time { get; set; }

        [Required]
        public DateTime Check_out_time { get; set; }
  
        public string Remarks { get; set; }

        //many to one
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        //one to one
        public Leaves Leave { get; set; }



    }
}
