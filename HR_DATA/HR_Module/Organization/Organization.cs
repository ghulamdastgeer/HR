using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HR_DATA.HR_Module.Organization
{
    public class Organization:HalfAuditEntity<int>
    {
        [Required]
        public string Name {get;set;}

        public List<Branch> Branches { get; set; }
    }
}