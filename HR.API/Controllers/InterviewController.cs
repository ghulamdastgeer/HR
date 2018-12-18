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
    public class InterviewController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitofwork;
        private readonly IInterviewRepository _repo;

        public InterviewController(IInterviewRepository repo, IUnitOfWork unitofWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitofwork = unitofWork;
            _repo = repo;
        }
        [HttpPost("AddInterview")]
        public async Task<IActionResult> AddInterview([FromBody]InterviewsResource InterviewResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var InterviewToAdd = _mapper.Map<InterviewsResource, Interviews>(InterviewResource);
            _repo.AddInterview(InterviewToAdd);
            await _unitofwork.CompleteAsync();
            return StatusCode(201);
        }

        [HttpGet("GetInterviews")]
        public async Task<IEnumerable<InterviewsResource>> GetInterviews()
        {
            List<Interviews> Interviews = await _repo.GetAllInterviewsAsync();
            return _mapper.Map<List<Interviews>, List<InterviewsResource>>(Interviews);

        }


        [HttpDelete("DeleteInterview")]
        public async Task<IActionResult> DeleteInterview(int id)
        {
            Interviews interview = await _repo.Get(id);
            _repo.RemoveInterviews(interview);
            await _unitofwork.CompleteAsync();
            return Ok(id);
        }

        [HttpPut("UpdateInterview")]
        public async Task<IActionResult> UpdateInterview(int id, [FromBody] InterviewsResource interviewResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Interviews interview = await _repo.Get(id);
            if (interview == null)
                return NotFound();
            _mapper.Map<InterviewsResource, Interviews>(interviewResource, interview);
            await _unitofwork.CompleteAsync();
            return StatusCode(202);
        }
    }
}