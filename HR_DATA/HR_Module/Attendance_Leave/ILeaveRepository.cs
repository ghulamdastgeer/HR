using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR_DATA.HR_Module.Attendance_Leave
{
   public interface ILeaveRepository
    {
        void AddLeave(Leaves leave);

        void RemoveLeave(Leaves leaves);
        Task<Leaves> Get(int id);
        Task<List<Leaves>> GetAllLeaves();
        Task<Leaves> GetLeavesByAttendaceId(int id);
    }
}
