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
    public class JobPostingController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitofwork;
        private readonly IJobPostingRepository _repo;

        public JobPostingController(IJobPostingRepository repo, IUnitOfWork unitofWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitofwork = unitofWork;
            _repo = repo;
        }
        [HttpPost("AddJobPosting")]
        public async Task<IActionResult> AddJobPosting([FromBody]JobPostingResource JobPostingResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var JobPostingToAdd = _mapper.Map<JobPostingResource, JobPosting>(JobPostingResource);
            _repo.CreateJobPosting(JobPostingToAdd);
            await _unitofwork.CompleteAsync();
            return StatusCode(201);
        }

        [HttpGet("GetJobPostings")]
        public async Task<IEnumerable<JobPostingResource>> GetJobPostings()
        {
            List<JobPosting> jobPostings = await _repo.GetAllJobPostings();
            return _mapper.Map<List<JobPosting>, List<JobPostingResource>>(jobPostings);

        }


        [HttpDelete("DeleteJobPostings")]
        public async Task<IActionResult> DeleteJobPostings(int id)
        {
            JobPosting jobPosting = await _repo.Get(id);
            _repo.RemoveJobPosting(jobPosting);
            await _unitofwork.CompleteAsync();
            return Ok(id);
        }

        [HttpPut("UpdateJobPosting")]
        public async Task<IActionResult> UpdateJobPosting(int id, [FromBody] JobPostingResource jobPostingResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            JobPosting jobPosting = await _repo.Get(id);
            if (jobPosting == null)
                return NotFound();
            _mapper.Map<JobPostingResource, JobPosting>(jobPostingResource, jobPosting);
            await _unitofwork.CompleteAsync();
            return StatusCode(202);
        }
    }
}
