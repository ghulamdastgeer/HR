using HR_DATA.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_DATA.HR_Module.Attendance_Leave
{
    public class LeaveRepository:ILeaveRepository
    {
        private  readonly DataContext _Context;

        public LeaveRepository(DataContext context)
        {
            _Context = context;
        }

        public void AddLeave(Leaves leave)
        {
            _Context.Leaves.Add(leave);
        }

        public async Task<Leaves> Get(int id)
        {
           return await _Context.Leaves.FindAsync(id);
        }

        public async Task<List<Leaves>> GetAllLeaves()
        {
            return await _Context.Leaves.ToListAsync();
        }

        public async Task<Leaves> GetLeavesByAttendaceId(int id)
        {
            return await _Context.Leaves.Where(a => a.AttendanceId == id).FirstOrDefaultAsync();
        }

        public void RemoveLeave(Leaves leaves)
        {
            _Context.Remove(leaves);
        }
    }
}
