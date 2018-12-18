using System;
using static HR_DATA.HR_Module.DataUtils;

namespace HR_DATA.HR_Module.Recruitement
{
    public class Interviews:HalfAuditEntity<int>
    {
        public DateTime Date { get; set; }

        public InterviewType type { get; set; }

        public Selected Selected { get; set; }

        //one to one
        public int ApplicantsId { get; set; }
        public Applicants Applicants { get; set; }
    }
}
