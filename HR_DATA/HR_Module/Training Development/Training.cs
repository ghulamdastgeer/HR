using HR_DATA.HR_Module.Organization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static HR_DATA.HR_Module.DataUtils;

namespace HR_DATA.HR_Module.Training_Development
{
    public class Training:HalfAuditEntity<int>
    {

       
        public string TrainingAgenda { get; set; }

        public int Budget { get; set; }

        public TrainingType type { get; set; }

        public DateTime Startdate { get; set; }

        public DateTime Enddate { get; set; }


        [DataType(DataType.MultilineText)]
        public string Remarks { get; set; }

        public List<EmployeeTraining> EmployeeTraining { get; set; }

    }
}
