using HR_DATA.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR_DATA.HR_Module.Training_Development
{
    public class EmployeeTrainingRepository : IEmployeeTrainingRepository
    {
        private readonly DataContext _Context;

        public EmployeeTrainingRepository(DataContext context)
        {
            _Context = context;

        }
        public void AddEmployeeTraining(EmployeeTraining EmployeeTraining)
        {
            _Context.EmployeeTrainings.Add(EmployeeTraining);
        }

        public async Task<EmployeeTraining> Get(int EmployeeId, int TrainingId)
        {
          return await  _Context.EmployeeTrainings.FindAsync(EmployeeId, TrainingId);
        }

        public void RemoveEmployeeTraining(EmployeeTraining EmployeeTraining)
        {
            _Context.Remove(EmployeeTraining);
        }
    }
}
