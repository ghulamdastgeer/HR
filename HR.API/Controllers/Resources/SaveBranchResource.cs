using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.API.Controllers.Resources
{
    public class SaveBranchResource
    {
        public SaveBranchResource()
        {
            
            Address = new SaveAddressResource();
        }

        public string Name { get; set; }

        public int OrganizationId { get; set; }
    
        public SaveAddressResource Address { get; set; }
    }
}
