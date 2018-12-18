using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HR.API.Controllers.Resources;
using HR_DATA.HR_Module.Recruitement;
using HR_DATA.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitofwork;
        private readonly IApplicantRepository _repo;

        public ApplicantController(IApplicantRepository repo, IUnitOfWork unitofWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitofwork = unitofWork;
            _repo = repo;
        }
        [HttpPost("AddApplicant")]
        public async Task<IActionResult> AddApplicant([FromBody]ApplicantResource ApplicantResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ApplicantToAdd = _mapper.Map<ApplicantResource, Applicants>(ApplicantResource);
            _repo.AddApplicant(ApplicantToAdd);
            await _unitofwork.CompleteAsync();
            return StatusCode(201);
        }

        [HttpGet("GetApplicants")]
        public async Task<IEnumerable<ApplicantResource>> GetApplicants()
        {
           List<Applicants> Applicants = await _repo.GetAllApplicants();
            return  _mapper.Map<List<Applicants>, List<ApplicantResource>>(Applicants);

        }


        [HttpDelete("DeleteApplicant")]
        public async Task<IActionResult> DeleteApplicant(int id)
        {
            Applicants Applicant = await _repo.Get(id);
            _repo.RemoveApplicant(Applicant);
            await _unitofwork.CompleteAsync();
            return Ok(id);
        }

        [HttpPut("UpdateJobPosting")]
        public async Task<IActionResult> UpdateApplicant(int id, [FromBody] ApplicantResource ApplicantResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Applicants applicants = await _repo.Get(id);
            if (applicants == null)
                return NotFound();
            _mapper.Map<ApplicantResource, Applicants>(ApplicantResource, applicants);
            await _unitofwork.CompleteAsync();
            return StatusCode(202);
        }
    }
}