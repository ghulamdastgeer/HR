using HR_DATA.Data;
using HR_DATA.HR_Module.Attendance_Leave;
using HR_DATA.HR_Module.BusinessGoals;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HR_DATA.HR_Module.DataUtils;

namespace HR_DATA.HR_Module.EmployeePerformances
{
    public class EmployeePerformanceRepository : IEmployeePerformanceRepository
    {
        private readonly DataContext _Context;
        
        public EmployeePerformanceRepository(DataContext context)
        {
            _Context = context;
        }
        public  void CaculatePerformance(EmployeePerformance performance)
        {
             _Context.EmployeePerformances.Add(performance);
        }
       
       
        public async Task<Performance> Get(int id)
        {
                return await _Context.Performance.FindAsync(id);
        }

        public async Task<List<Performance>> GetAllPerformances(bool includeReleated = true)
        {
            if (!includeReleated)
                return await _Context.Performance.ToListAsync();

            return await _Context
                     .Performance
                     //.Include(v => v.Employee)
                     .ToListAsync();
        }

        public void Removeperformance(Performance performance)
        {
            _Context.Remove(performance);
        }
    }
}
