using HR_DATA.HR_Module.Organization;
using System;
using static HR_DATA.HR_Module.DataUtils;

namespace HR_DATA.HR_Module.Attendance_Leave
{
    public class Leaves:HalfAuditEntity<int>
    {
        public DayOfWeek Days { get; set; }

        public LeaveStatus LeaveStatus { get; set; }

        public Leave  LeaveType { get;set; }

        //one to one         
        public int AttendanceId { get; set; }
        public Attendance Attendance { get; set; }
        
        

    }
}
