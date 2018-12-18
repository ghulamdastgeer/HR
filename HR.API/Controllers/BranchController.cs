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
    public class BranchController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitofwork;
        private readonly IBranchRepository _repo;
        public BranchController(IBranchRepository repo,IUnitOfWork unitOfWork,IMapper mapper)
        {
            _mapper = mapper;
            _unitofwork = unitOfWork;
            _repo = repo;
        }
        [HttpPost]
        public async Task<IActionResult> CreateBranches([FromBody]SaveBranchResource BranchResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var BranchToCreate = _mapper.Map<SaveBranchResource, Branch>(BranchResource);
            _repo.CreateBranch(BranchToCreate);
            await _unitofwork.CompleteAsync();
            //var CreatedBranch = await _repo.Get(BranchToCreate.Id, includeRelated: false);
            //var result = _mapper.Map<Organization>(CreatedBranch);
            // return Ok(result);
            return StatusCode(201);
        }
        [HttpGet]

        public async Task<IEnumerable<BranchResource>> GetBranches()
        {
            List<Branch> Branches = await _repo.GetAllBranches();

            return _mapper.Map<List<Branch>, List<BranchResource>>(Branches);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBranch(int id)
        {
            Branch branch = await _repo.Get(id);
            _repo.RemoveBranch(branch);
            await _unitofwork.CompleteAsync();
            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBranch(int id,[FromBody]SaveBranchResource BranchResource )
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Branch branch = await _repo.Get(id);
            if (branch == null)
                return NotFound();
            _mapper.Map<SaveBranchResource, Branch>(BranchResource,branch);
            await _unitofwork.CompleteAsync();
            return StatusCode(202);
        }




    }
}