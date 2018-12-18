using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HR.API.Controllers.Resources;
using HR_DATA.HR_Module.Organization;
using HR_DATA.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitofwork;
        private readonly IOrganizationRepository _repo;

        public OrganizationController(IOrganizationRepository repo, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitofwork = unitOfWork;
            _repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrganization([FromBody]SaveOrganizationResource OrganizationResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
         
           var OrganizationToCreate =_mapper.Map<SaveOrganizationResource, Organization>(OrganizationResource);
            _repo.CreateOrganization(OrganizationToCreate);
            await _unitofwork.CompleteAsync();
            var CreatedOrganization =await _repo.Get(OrganizationToCreate.Id,includeRelated : false);
            var result = _mapper.Map<Organization>(CreatedOrganization);
            return Ok(result);
        }


        [HttpGet]
        public async Task<IEnumerable<OrganizationResource>> GetOrganization()
        {
            List<Organization> org = await _repo.GetAllOrganizations();
            return _mapper.Map<List<Organization>, List<OrganizationResource>>(org);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrganization(int id)
        {
            Organization organization = await _repo.Get(id, includeRelated: false);
            _repo.Remove(organization);
            await _unitofwork.CompleteAsync();
            return Ok(id);
        }

      [HttpPut("{id}")]
      
      public async Task<IActionResult> UpdateOrganization(int id,[FromBody]SaveOrganizationResource organizationResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Organization  organization = await _repo.Get(id,includeRelated: false);
            if (organization == null)
                return NotFound();
            _mapper.Map <SaveOrganizationResource, Organization>(organizationResource,organization);
            await _unitofwork.CompleteAsync();
            return StatusCode(201);

        }

     

    }
}