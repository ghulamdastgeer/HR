using HR_DATA.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR_DATA.Helper;

namespace HR_DATA.HR_Module.Organization
{
  public  class EmployeeRepository:IEmployeeRepository
    {
        private DataContext _Context;

        public EmployeeRepository(DataContext context)
        {
            _Context = context;
        }

        public void CreateEmployee(Employee employee)
        {
        
            _Context.Employees.AddAsync(employee);
        }

        public async Task<Employee> Get(int id, bool includeRelated = true)
        {
            if (!includeRelated)
                return await _Context.Employees.FindAsync(id);
            return await _Context.Employees
                .Include(b => b.Salary)
                .Include(b=>b.EmployeeDesignation)
                .Include(b=>b.Benefits)
                .Include(b=>b.Address)
                .Include(b=>b.EmployeeImages)
                .SingleOrDefaultAsync(v=>v.Id==id);
        }
        public async Task<PagedList<Employee>> GetAllEmployees(EmployeeParams Params)
        {

            var employee = _Context.Employees
               .Include(b => b.Salary)
               .Include(b => b.EmployeeDesignation)
               .Include(b => b.Address)
               .AsQueryable();
            if (!string.IsNullOrEmpty(Params.Name))
            {
                employee = employee.Where(u => u.Name == Params.Name);
            }

            if (!string.IsNullOrEmpty(Params.Designation))
            {
                employee = employee.Where(u => u.EmployeeDesignation.Name == Params.Designation);
            }

            if (Params.Gender!=null)
            {
                employee = employee.Where(u => u.Gender == Params.Gender);
            }

            if (Params.MinSalary!= 10000 || Params.MaxSalary!= 1000000)
            {
                employee = employee.Where(u => u.Salary.Salaries >= Params.MinSalary && u.Salary.Salaries <= Params.MaxSalary);
            }

            if (!string.IsNullOrEmpty(Params.OrderBy))
            {
                switch (Params.OrderBy)
                {
                    case "Salary":
                        employee = employee.OrderByDescending(u => u.Salary.Salaries);
                        break;
                    case "Gender":
                        employee = employee.OrderByDescending(u => u.Gender);
                        break;
                    case "Department":
                        employee = employee.OrderByDescending(u => u.Department.Name);
                        break;
                    case "Designation":
                        employee = employee.OrderByDescending(u => u.EmployeeDesignation.Name);
                        break;

                    default:
                        employee = employee.OrderByDescending(u => u.Name);
                        break;
                }
            }

            return await PagedList<Employee>.CreateAsync(employee, Params.PageNumber, Params.PageSize);


        }
        public void RemoveEmployee(Employee employee)
        {
            _Context.Remove(employee);
        }

        
    }
}
