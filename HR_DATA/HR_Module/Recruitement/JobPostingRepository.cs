using HR_DATA.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR_DATA.HR_Module.Recruitement
{
   public class JobPostingRepository:IJobPostingRepository
    {
        private readonly DataContext _Context;

        public JobPostingRepository(DataContext context)
        {
            _Context = context;
        }
        public void CreateJobPosting(JobPosting jobPosting)
        {
            _Context.JobPostings.AddAsync(jobPosting);
        }
        public async Task<JobPosting> Get(int id, bool includeRelated = true)
        {
            if (!includeRelated)
                return await _Context.JobPostings.FindAsync(id);

            return await _Context.JobPostings
                .Include(a => a.Applicants)
                .SingleOrDefaultAsync(v => v.Id == id);
                
        }

        public async Task<List<JobPosting>> GetAllJobPostings(bool includeRelated = true)
        {
            if (!includeRelated)
                return await _Context.JobPostings.ToListAsync();

            return await _Context.JobPostings
                .Include(a => a.Applicants)
                .ToListAsync();
        }

        public void RemoveJobPosting(JobPosting jobPosting)
        {
            _Context.Remove(jobPosting);
        }
    }
}
