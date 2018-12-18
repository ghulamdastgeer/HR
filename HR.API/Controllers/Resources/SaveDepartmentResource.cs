using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.API.Controllers.Resources
{
    public class SaveDepartmentResource
    {
        public string Name { get; set; }

        //one to many
        public int BranchId { get; set; }


    }
}
