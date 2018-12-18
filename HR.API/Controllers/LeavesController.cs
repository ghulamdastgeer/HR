using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HR.API.Controllers.Resources;
using HR_DATA.HR_Module.Attendance_Leave;
using HR_DATA.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeavesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitofwork;
        private readonly ILeaveRepository _repo;

        public LeavesController(IMapper mapper, IUnitOfWork unitOfWork, ILeaveRepository repo)
        {
            _mapper = mapper;
            _unitofwork = unitOfWork;
            _repo = repo;
        }
        [HttpPost("AddLeave")]
        public async Task<IActionResult> AddLeave(LeaveResource LeaveResource)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var LeaveToAdd = _mapper.Map<LeaveResource, Leaves>(LeaveResource);
            _repo.AddLeave(LeaveToAdd);
            await _unitofwork.CompleteAsync();
            return StatusCode(201);
        }
        [HttpGet("GetLeaves")]

        public async Task<IEnumerable<LeaveResource>> GetLeaves()
        {
            List<Leaves> leaves = await _repo.GetAllLeaves();

            return _mapper.Map<List<Leaves>, List<LeaveResource>>(leaves);
        }

        [HttpPost(" GetLeavesByAttendanceId")]
        public async Task<LeaveResource> GetLeavesByAttendanceId(int id)
        {
            var Leaves = await _repo.GetLeavesByAttendaceId(id);

            return _mapper.Map <Leaves,LeaveResource>(Leaves);
        }
        [HttpPut("UpdateLeave")]
        public async Task<IActionResult> UpdateLeaves(int id, [FromBody]LeaveResource LeaveResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var Leaves = await _repo.Get(id);
            if (Leaves == null)
                return NotFound();
            _mapper.Map<LeaveResource, Leaves>(LeaveResource, Leaves);
            await _unitofwork.CompleteAsync();
            return StatusCode(202);
        }



        [HttpDelete("RemoveLeave")]
        public async Task<IActionResult> RemoveLeave(int Id)
        {
            Leaves leaves = await _repo.Get(Id);
            _repo.RemoveLeave(leaves);
            await _unitofwork.CompleteAsync();
            return Ok(Id);
        }

    }

}
