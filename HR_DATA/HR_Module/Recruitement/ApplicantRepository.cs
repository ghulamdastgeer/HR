using HR_DATA.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR_DATA.HR_Module.Recruitement
{
    public class ApplicantRepository : IApplicantRepository
    {
        private readonly DataContext _Context;

        public ApplicantRepository(DataContext context)
        {
            _Context = context;
        }
        public void AddApplicant(Applicants applicant)
        {
            _Context.Applicants.AddAsync(applicant);
        }

        public async Task<Applicants> Get(int id, bool includeRelated=true)
        {
            if(!includeRelated)
                return await _Context.Applicants.FindAsync(id);

            return await _Context.Applicants.Include(a => a.JobApplications).SingleOrDefaultAsync(v=>v.Id==id);
        }

        public async Task<List<Applicants>> GetAllApplicants(bool includeRelated = true)
        {
            if(!includeRelated)
                 return await _Context.Applicants.ToListAsync();

            return await _Context.Applicants.Include(a => a.JobApplications).ToListAsync();
        }

        public void RemoveApplicant(Applicants applicant)
        {
            _Context.Remove(applicant);
        }
    }
}
