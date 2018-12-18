using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static HR_DATA.HR_Module.DataUtils;

namespace HR.API.Controllers.Resources
{
    public class EmployeeTasksResources
    {
        [Required]
        [DataType(DataType.MultilineText)]
        public string BusinessGoals { get; set; }

        public DateTime Start { get; set; }
        public DateTime DeadLine { get; set; }

        public int TaskAssiningAuthId { get; set; }

        public TaskStatus Status { get; set; }

        public int EmployeeId { get; set; }

        public DateTime TaskCompleted { get; set; }
        public bool? Deadlinemeet { get; set; }
    }

}