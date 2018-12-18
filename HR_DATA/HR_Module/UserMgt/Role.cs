using System.Collections.Generic;

namespace HR_DATA.HR_Module.UserMgt
{
    public class Role:HalfAuditEntity<int>
    {
        
        public string Name {get;set;}

        //one to many
        public List<User> User { get; set; }
    }
}