using HR_DATA.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_DATA.HR_Module.Attendance_Leave
{
    public class AttendanceRepositroy:IAttendanceRepository
    {
        private readonly DataContext _Context;

        public AttendanceRepositroy(DataContext context)
        {
            _Context = context;
        }
        public async Task<List<Attendance>> GetAttendance(int EmployeeId)
        {
            return await _Context.Attendance.Where(
               a => a.EmployeeId == EmployeeId
               && a.Status == DataUtils.AttendanceType.Present).ToListAsync();

        }
        public void AddAttendance(List<Attendance> attendances)
        {
            foreach (Attendance attendance in attendances )
            {
                _Context.Attendance.Add(attendance);
            }           
        }
        public void AddAttendance(Attendance attendance)
        {
            _Context.Attendance.Add(attendance);
        }

        public async Task<Attendance> Get(int id)
        {
          return await  _Context.Attendance.FindAsync(id);
            
        }
        public async  Task<List<Attendance>> GetAttendanceByEmployee(int id)
        {
            return await _Context.Attendance.Where(a => a.EmployeeId == id).ToListAsync();

        }

        public async Task<List<Attendance>> GetAllAttendance()
        {
          return await  _Context.Attendance.ToListAsync();
        }

        public void RemoveAttendance(Attendance attendance)
        {
            _Context.Remove(attendance);
        }

      
    }
}
