using HR_DATA.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR_DATA.HR_Module.Organization
{
    public interface IOrganizationRepository //:IRepository<Organization>
    {
        void CreateOrganization(Organization org);
        Task<Organization> Get(int id, bool includeRelated = true);
        Task<List<Organization>> GetAllOrganizations(bool includeRelated=true);
        void Remove(Organization organization);
       

    }
}
