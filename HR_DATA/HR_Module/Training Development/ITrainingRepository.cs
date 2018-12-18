using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR_DATA.HR_Module.Training_Development
{
   public interface ITrainingRepository
    {
        void AddTrainings(Training Trainings);

        void RemoveTrainings(Training Training);
        Task<Training> Get(int id);
        Task<List<Training>> GetAllTrainings();

    }
}
