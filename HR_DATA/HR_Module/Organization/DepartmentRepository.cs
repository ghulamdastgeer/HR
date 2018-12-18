using HR_DATA.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace HR_DATA.HR_Module.Organization
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private DataContext _Context;

        public DepartmentRepository(DataContext context)  
        {
            _Context = context;
        }
        public void  CreateDept(Departments dept)
        {
             _Context.Departments.AddAsync(dept);
        }
        public async Task<Departments>Get(int id,bool includeRelated=false)
        {
            if (!includeRelated)
                return await _Context.Departments.FindAsync(id);
            return await _Context.Departments
                .Include(b => b.Employees)
                .FirstOrDefaultAsync();
        }
        public void RemoveDept(Departments depts)
        {
            _Context.Remove(depts);
        }

        public async Task<List<Departments>> GetAllDepartments(bool includeRelated = false)
        {
            if (!includeRelated)
                return await _Context.Departments.ToListAsync();

            return await _Context.Departments
                .Include(o => o.Employees)
                .ToListAsync();
        }
    }
}
