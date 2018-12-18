using HR_DATA.HR_Module.Addresses;
using System.Collections.Generic;
namespace HR_DATA.HR_Module.Organization
{
    public class Branch:HalfAuditEntity<int>
    {  
          
        public string Name { get; set; }
        //many to one
        public int OrganizationID { get; set; }
        public Organization Organization {get;set;}

        //one to many
        public List<Departments> Departments { get; set; }
        
        //one to one
        public Address Address { get; set; }

    }
}
