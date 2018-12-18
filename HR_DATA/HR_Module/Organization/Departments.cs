using System.Collections.Generic;

namespace HR_DATA.HR_Module.Organization
{
    public class Departments:HalfAuditEntity<int>
    {
        

        public string Name { get; set; }

        //one to many
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
        
        //one to many
        public List<Employee> Employees { get; set; }

    }
}