using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.API.Controllers.Resources
{
    public class OrganizationResource
    {
         public OrganizationResource()
        {
          Branches = new List<SaveBranchResource>();
         }
        public int Id { get; set; }
        public string Name { get; set; }

        public List<SaveBranchResource> Branches { get; set; }
    }
}
