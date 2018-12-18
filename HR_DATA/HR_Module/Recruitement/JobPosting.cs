using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HR_DATA.HR_Module.Recruitement
{
    public class JobPosting:HalfAuditEntity<int>
    {

        public string JobTitle { get; set; }


        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        public string ImagUrl { get; set; }

        public  int Vaccancies{get;set;}

        //public string JobPoster { get; set; }
        
        //one to many
        public List<Applicants> Applicants { get; set; }


    }
}
