using HR_DATA.HR_Module.Organization;
using System;

namespace HR_DATA.HR_Module.UserMgt
{
    public class User:HalfAuditEntity<int>
    {
        public string UserName { get; set; }
        
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime LastActive { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        //one to one
        public int RoleId { get; set; }
        public Role Role { get; set; }

        public bool IsInRole(int id)
        {
            return Role != null && Role.Id == id;
        }
        public Employee Employee { get; set; }

    }
}
