using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR_DATA.HR_Module.Attendance_Leave
{
   public interface IAttendanceRepository
    {
        Task<List<Attendance>> GetAttendance(int EmployeeId);
        void AddAttendance(Attendance attendance);
        void AddAttendance(List<Attendance> attendances);
        void RemoveAttendance(Attendance attendance);
        Task<Attendance> Get(int id);
        Task<List<Attendance>> GetAttendanceByEmployee(int id);
        Task<List<Attendance>> GetAllAttendance();

    }
}
