using HR_DATA.HR_Module.EmployeePerformances;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR_DATA.HR_Module.EmployeePerformances
{
  public interface IEmployeePerformanceRepository
    {
        void CaculatePerformance(EmployeePerformance performance);
        void Removeperformance(Performance performance);
        Task<Performance> Get(int id);
        Task<List<Performance>> GetAllPerformances(bool includeReleated = true);
    }
}
