using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static HR_DATA.HR_Module.DataUtils;

namespace HR.API.Controllers.Resources
{
    public class InterviewsResource
    {
        public DateTime Date { get; set; }
        public InterviewType type { get; set; }
        public Selected Selected { get; set; }
        public int ApplicantsId { get; set; }
    }
}
