using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR_DATA.HR_Module.BusinessGoals
{
   public interface ITaskRepository
    {
        Task<List<EmployeeTasks>> GetDeadline();
        Task<List<EmployeeTasks>> GetTaskByEmployeeId(int id);
         Task<List<EmployeeTasks>> TaskStatus();
       
        void AddTasks(EmployeeTasks Tasks);

        void RemoveTasks(EmployeeTasks Tasks);
        Task<EmployeeTasks> Get(int id);
        Task<List<EmployeeTasks>> GetAllTasks();
    }
}
