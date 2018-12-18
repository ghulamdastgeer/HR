using HR_DATA.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR_DATA.HR_Module.Benefit
{
    public class BenefitsRepository:IBenefitsRepository
    {
        private readonly DataContext _Context;

        public BenefitsRepository(DataContext context)
        {
            _Context = context;
        }

        public void AddBenefits(Benefits benefits)
        {
            
            _Context.Benefits.AddAsync(benefits);
        }

      

        public async Task<Benefits> Get(int id)
        {
                return await _Context.Benefits.FindAsync(id);
        }

        public async Task<List<Benefits>> GetAllBenefits()
        {
            return await _Context.Benefits.ToListAsync();
        }

        public void RemoveBenefits(Benefits benefit)
        {
            _Context.Remove(benefit);
        }
    }
}
