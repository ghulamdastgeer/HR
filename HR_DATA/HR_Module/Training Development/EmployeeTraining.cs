using HR_DATA.HR_Module.Organization;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR_DATA.HR_Module.Training_Development
{
   public class EmployeeTraining
    {
       
           public EmployeeTraining ()
            {
                CreationTime = DateTime.Now;
            
        }

        public DateTime CreationTime { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int TrainingsId { get; set; }
        public Training Trainings { get; set; }
       
    }
}
