using HR_DATA.HR_Module.Attendance_Leave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static HR_DATA.HR_Module.DataUtils;

namespace HR.API.Controllers.Resources
{
    public class LeaveResource
    {
        public DayOfWeek Days { get; set; }

        public LeaveStatus LeaveStatus { get; set; }

        public Leave LeaveType { get; set; }

        //one to one         
        public int AttendanceId { get; set; }

        //one to one
        public int EmployeeId { get; set; }


    }
}
