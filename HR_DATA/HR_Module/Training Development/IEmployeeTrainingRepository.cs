using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR_DATA.HR_Module.Training_Development
{
  public  interface IEmployeeTrainingRepository
    {
        void AddEmployeeTraining(EmployeeTraining EmployeeTraining);
        void RemoveEmployeeTraining(EmployeeTraining EmployeeTraining);
        Task<EmployeeTraining> Get(int EmployeeId, int TrainingId);
    }
}
