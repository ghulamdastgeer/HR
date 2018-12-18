using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR_DATA.HR_Module.Recruitement
{
  public  interface IApplicantRepository
    {
        void AddApplicant(Applicants applicant);
        Task<Applicants> Get(int id, bool includeRelated = true);
        void RemoveApplicant(Applicants applicant);
        Task<List<Applicants>> GetAllApplicants(bool includeRelated = true);

    }
}
