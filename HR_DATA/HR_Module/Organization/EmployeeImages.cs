using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HR_DATA.HR_Module.Organization
{
 public  class EmployeeImages:HalfAuditEntity<int>
    {

        [MaxLength(50)]
        public string Caption { get; set; }

        public int Priority { get; set; }

        [Required]
        [MaxLength(255)]
        public string Url { get; set; }

        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
    }
}
