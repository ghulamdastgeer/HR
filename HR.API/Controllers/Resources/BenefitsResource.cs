using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static HR_DATA.HR_Module.DataUtils;

namespace HR.API.Controllers.Resources
{
    public class BenefitsResource
    {
      
           public string Benefit { get; set; }
         public BenefitType Type { get; set; }
    }
}
