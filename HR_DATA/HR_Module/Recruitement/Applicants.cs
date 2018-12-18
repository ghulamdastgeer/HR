using static HR_DATA.HR_Module.DataUtils;

namespace HR_DATA.HR_Module.Recruitement
{
    public  class Applicants:HalfAuditEntity<int>
    {
       
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public Shortlisted Shortlist { get; set; }

        //public Estatus Estatus { get; set; }

        //one to one
        public Interviews Interviews { get; set; }

        public JobApplications JobApplications { get; set; }

        //one to many
        public int JobPostingId { get; set; }
        public JobPosting JobPosting { get; set; }
    }
}
