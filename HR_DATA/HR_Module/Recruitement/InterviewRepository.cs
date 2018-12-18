using HR_DATA.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HR_DATA.HR_Module.Recruitement
{
    public  class InterviewRepository:IInterviewRepository
    {
        private readonly DataContext _Context;

        public InterviewRepository(DataContext context)
        {
            _Context = context;
        }

        public void AddInterview(Interviews interviews)
        {
            _Context.Interviews.Add(interviews);
        }

        public async Task<Interviews> Get(int id)
        {
            return await _Context.Interviews.FindAsync(id);
        }

        public async Task<List<Interviews>> GetAllInterviewsAsync()
        {
            return await _Context.Interviews.ToListAsync();
        }


        public void RemoveInterviews(Interviews interviews)
        {
            _Context.Remove(interviews);
        }
    }
}
