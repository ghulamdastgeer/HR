using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.API.Controllers.Resources
{
    public class BranchResource
    {
        public BranchResource()
        {
            Departments = new List<DepartmentsResource>();
            Address = new AddressResource();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public List<DepartmentsResource> Departments { get; set; }

        public AddressResource Address { get; set; }
    }
}
