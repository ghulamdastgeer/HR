using HR_DATA.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR_DATA.HR_Module.Organization
{
    public interface IBranchRepository
    {
        void CreateBranch(Branch branch);
        void RemoveBranch(Branch branch);
        Task<Branch> Get(int id, bool includeRelated = true);
        Task<List<Branch>> GetAllBranches(bool includeRelated = true);
    }
}
