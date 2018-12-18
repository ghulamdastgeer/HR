using HR_DATA.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR_DATA.HR_Module.Organization
{
    public interface IDepartmentRepository 
    {
        void CreateDept(Departments dept);
        Task<Departments> Get(int id, bool includeRelated = false);
        void RemoveDept(Departments depts);
        Task<List<Departments>> GetAllDepartments(bool includeRelated = false);

    }
}
