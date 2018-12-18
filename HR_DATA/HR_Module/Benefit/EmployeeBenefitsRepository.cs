using HR_DATA.Data;
using HR_DATA.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR_DATA.HR_Module.Benefit
{
  public  class EmployeeBenefitsRepository:IEmployeeBenefitRepository
    {
        private readonly DataContext _Context;

        public EmployeeBenefitsRepository(DataContext context)
        {
            _Context = context;

        }
        public void AddEmployeeBenefits(EmployeeBenefits employeeBenefits)
        {
            _Context.EmployeeBenefits.Add(employeeBenefits);
        }

        public void RemoveEmployeeBenefit(EmployeeBenefits employeeBenefits)
        {
            _Context.EmployeeBenefits.Remove(employeeBenefits);
        }
        public async  Task<EmployeeBenefits> Get(int EmployeeId, int BenefitId)
        {
            return  await  _Context.EmployeeBenefits.FindAsync(EmployeeId,BenefitId);
        }
    }
}
