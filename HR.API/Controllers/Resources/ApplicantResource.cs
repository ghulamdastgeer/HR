using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static HR_DATA.HR_Module.DataUtils;

namespace HR.API.Controllers.Resources
{
    public class ApplicantResource
    {
        public ApplicantResource()
        {
            JobApplications = new JobApplicationResource();
        }
        public string Name { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }

        public Shortlisted Shortlist { get; set; }

    //    public Estatus Estatus { get; set; }


        public JobApplicationResource JobApplications { get; set; }

      
        public int JobPostingId { get; set; }
    }
}
