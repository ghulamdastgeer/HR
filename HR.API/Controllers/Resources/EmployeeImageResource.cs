using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.API.Controllers.Resources
{
    public class EmployeeImageResource
    {
        public int Id { get; set; }
        public string Caption { get; set; }
        public int Priority { get; set; }
        public string Url { get; set; }
        public int EmployeeId { get; set; }

    }
}
