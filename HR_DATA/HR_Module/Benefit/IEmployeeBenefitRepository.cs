using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR_DATA.HR_Module.Benefit
{
   public interface IEmployeeBenefitRepository
    {
        void AddEmployeeBenefits(EmployeeBenefits employeeBenefits);
        void RemoveEmployeeBenefit(EmployeeBenefits employeeBenefits);
        Task<EmployeeBenefits> Get(int EmployeeId, int BenefitId);
    }
}
