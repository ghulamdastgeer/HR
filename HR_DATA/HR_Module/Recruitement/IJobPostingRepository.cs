using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR_DATA.HR_Module.Recruitement
{
   public interface IJobPostingRepository
    {
        void CreateJobPosting(JobPosting jobPosting);
        Task<JobPosting> Get(int id, bool includeRelated = true);
        void RemoveJobPosting(JobPosting jobPosting);
        Task<List<JobPosting>> GetAllJobPostings(bool includeRelated = true);

    }
}
