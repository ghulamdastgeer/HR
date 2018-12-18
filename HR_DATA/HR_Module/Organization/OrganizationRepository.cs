using System.Collections.Generic;
using System.Threading.Tasks;
using HR_DATA.Data;
using Microsoft.EntityFrameworkCore;

namespace HR_DATA.HR_Module.Organization
{
    public class OrganizationRepository : IOrganizationRepository 
    {
        private readonly DataContext _Context;
        public OrganizationRepository(DataContext context) 
        {
            _Context = context;
        }
        public  void CreateOrganization(Organization org)
        {
             _Context.Organizations.AddAsync(org);
        }

        public async Task<Organization> Get(int id, bool includeRelated = true)
        {
            if (!includeRelated)
                return await _Context.Organizations.FindAsync(id);

            return await _Context.Organizations
                .Include(o => o.Branches)
                .SingleOrDefaultAsync();
        }

        public void Remove(Organization organization)
        {
            _Context.Remove(organization);
        }

        public async Task<List<Organization>> GetAllOrganizations(bool includeRelated = true)
        {
            if (!includeRelated)
                return await _Context.Organizations.ToListAsync();

            return await _Context.Organizations
                .Include(o => o.Branches)
                .ToListAsync();
        }
    }
}