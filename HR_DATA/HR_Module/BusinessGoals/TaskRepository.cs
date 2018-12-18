using HR_DATA.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HR_DATA.HR_Module.DataUtils;

namespace HR_DATA.HR_Module.BusinessGoals
{
  public  class TaskRepository:ITaskRepository
    {
        private readonly DataContext _Context;

        public TaskRepository(DataContext context)
        {
            _Context = context;
        }
        public async Task<List<EmployeeTasks>> GetDeadline()
        {
            return await _Context.EmployeeTasks.Where(a => a.Deadlinemeet == true).ToListAsync();

        }
        public async Task<List<EmployeeTasks>> TaskStatus()
        {
            return await _Context.EmployeeTasks.Where(a => a.Status == Taskstatus.Completed).ToListAsync();

        }
        public async Task<List<EmployeeTasks>> GetTaskByEmployeeId(int id)
        {
            return await _Context.EmployeeTasks.Where(a => a.EmployeeId == id).ToListAsync();
        }
        public void AddTasks(EmployeeTasks Tasks)
        {
            _Context.EmployeeTasks.AddAsync(Tasks);
        }

        public async Task<EmployeeTasks> Get(int id)
        {
            
                return await  _Context.EmployeeTasks.FindAsync(id);
         
        }

        public async Task<List<EmployeeTasks>> GetAllTasks()
        {
            return await _Context.EmployeeTasks.ToListAsync();
        }

        public void RemoveTasks(EmployeeTasks Tasks)
        {
            _Context.Remove(Tasks);
        }
    }
}
