using HR_DATA.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR_DATA.HR_Module.Training_Development
{
   public class TrainingRepository:ITrainingRepository
    {
        private readonly DataContext _Context;

        public TrainingRepository(DataContext context)
        {
            _Context = context;
        }

        public void AddTrainings(Training Training)
        {
            _Context.Trainings.Add(Training);
        }

        public async Task<Training> Get(int id)
        {
            return await _Context.Trainings.FindAsync(id);
        }

        public async Task<List<Training>> GetAllTrainings()
        {
            return await _Context.Trainings.ToListAsync();
        }

        public void RemoveTrainings(Training Training)
        {
            _Context.Remove(Training);
        }
    }
}
