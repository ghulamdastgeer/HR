using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_DATA.HR_Module.Recruitement
{
    public class JobApplications:HalfAuditEntity<int>
    {
        public string ResumeURL{get;set;}

        public int ApplicantsId { get; set; }
        public Applicants Applicants { get; set; }

    }
}
