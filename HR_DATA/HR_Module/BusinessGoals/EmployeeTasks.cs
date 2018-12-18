
using HR_DATA.HR_Module.Organization;
using System;
using System.ComponentModel.DataAnnotations;
using static HR_DATA.HR_Module.DataUtils;

namespace HR_DATA.HR_Module.BusinessGoals
{
    public class EmployeeTasks:HalfAuditEntity<int>
    {
        [Required]
        [DataType(DataType.MultilineText)]
        public string BusinessGoals { get; set; }
        public DateTime Start { get; set; }
        public DateTime DeadLine { get; set; }
        public int? TaskAssiningAuthId { get; set; }
        public Employee TaskAssigingAuth { get; set; }
        public Taskstatus Status { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public DateTime? TaskCompleted { get; set; }
        public bool? Deadlinemeet { get; set; }
      }
    }

