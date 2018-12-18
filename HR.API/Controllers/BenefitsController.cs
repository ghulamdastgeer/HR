using AutoMapper;
using HR.API.Controllers.Resources;
using HR_DATA.HR_Module.Benefit;
using HR_DATA.HR_Module.Organization;
using HR_DATA.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BenefitsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitofwork;
        private readonly IBenefitsRepository _repo;
        public BenefitsController(IBenefitsRepository repo,IUnitOfWork unitofWork,IMapper mapper)
        {
            _mapper = mapper;
            _unitofwork = unitofWork;
            _repo = repo;
           
        }
        [HttpPost]
        public async Task<IActionResult> AddBenefit([FromBody]BenefitsResource BenefitsResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var BenefitToAdd = _mapper.Map<BenefitsResource,Benefits>(BenefitsResource);
            _repo.AddBenefits(BenefitToAdd);
            await _unitofwork.CompleteAsync();
            return StatusCode(201);
        }
       
        [HttpGet]
        public async Task<IEnumerable<TrainingResource>> GetBenefits()
        {
            List<Benefits> benefits = await _repo.GetAllBenefits();
            return _mapper.Map<List<TrainingResource>>(benefits);
            
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteBenefit(int id)
        {
            Benefits benefit = await _repo.Get(id);
            _repo.RemoveBenefits(benefit);
            await _unitofwork.CompleteAsync();
            return Ok(id);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBenefits(int id, [FromBody] BenefitsResource benefitsresource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

           Benefits benefits = await _repo.Get(id);
            if (benefits == null)
                return NotFound();
            _mapper.Map(benefitsresource, benefits);
            await _unitofwork.CompleteAsync();
            return StatusCode(202);
            
        }

    }
}