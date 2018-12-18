using HR_DATA.Data;
using HR_DATA.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HR_DATA.HR_Module.Organization
{
    public class BranchRepository : IBranchRepository
    {
        private readonly DataContext _Context;
        public BranchRepository(DataContext context) {
            _Context = context;
        }

        public void CreateBranch(Branch branch)
        {
            _Context.Entry(branch.Address).State = EntityState.Added;
            //_Context.Entry(branch.Address.City).State = EntityState.Unchanged;
             _Context.Branches.AddAsync(branch);
        }
        public async Task<Branch> Get(int id,bool includeRelated=true)
        {
            if (!includeRelated)
                return await _Context.Branches.FindAsync(id);

            return await _Context.Branches
               .Include(b => b.Address)
               .SingleOrDefaultAsync(v=>v.Id==id);
        }
       
        public void RemoveBranch(Branch branch)
        {
            _Context.Entry(branch.Address).State = EntityState.Deleted;
            _Context.Remove(branch);
        }

        public async Task<List<Branch>> GetAllBranches(bool includeRelated=true)
        {
            if (!includeRelated)
                return await _Context.Branches.ToListAsync();

            return await _Context.Branches
                .Include(o => o.Address)
                .Include(o=>o.Departments)
                .ToListAsync();
        }
    }
}
