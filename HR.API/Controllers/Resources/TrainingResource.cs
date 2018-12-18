using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static HR_DATA.HR_Module.DataUtils;

namespace HR.API.Controllers.Resources
{
    public class TrainingResource
    {
        public TrainingResource()
        {
            EmployeeTraining = new List<EmployeeTrainingResource>();
        }
        public string TrainingAgenda { get; set; }

        public int Budget { get; set; }

        public TrainingType type { get; set; }

        public DateTime Startdate { get; set; }

        public DateTime Enddate { get; set; }


        [DataType(DataType.MultilineText)]
        public string Remarks { get; set; }

        public List<EmployeeTrainingResource> EmployeeTraining { get; set; }


    }
}
