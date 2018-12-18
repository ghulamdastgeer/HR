using HR_DATA.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR_DATA.HR_Module.Benefit
{
    public interface IBenefitsRepository
    {
        void AddBenefits(Benefits benefits);
       
        void RemoveBenefits(Benefits benefit);
        Task<Benefits> Get(int id);
        Task<List<Benefits>> GetAllBenefits();


    }
}
