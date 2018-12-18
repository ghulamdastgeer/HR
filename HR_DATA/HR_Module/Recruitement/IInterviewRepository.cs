
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR_DATA.HR_Module.Recruitement
{
   public interface IInterviewRepository
    {
        void AddInterview(Interviews interviews);
        Task<Interviews> Get(int id);
        void RemoveInterviews(Interviews interviews);
        Task<List<Interviews>> GetAllInterviewsAsync();

    }
}
