using System.Collections.Generic;
using System.Threading.Tasks;
using HR_DATA.Helper;
namespace HR_DATA.HR_Module.Organization
{
    public  interface IEmployeeRepository
    {
        void CreateEmployee(Employee employee);
        Task<Employee> Get(int id, bool includeRelated = true);
        void RemoveEmployee(Employee employee);
        Task<PagedList<Employee>> GetAllEmployees(EmployeeParams Params);

    }
}
