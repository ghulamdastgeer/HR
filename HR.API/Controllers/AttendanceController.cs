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
    public class AttendanceController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitofwork;
        private  readonly IAttendanceRepository _repo;

        public AttendanceController(IMapper mapper,IUnitOfWork unitOfWork,IAttendanceRepository repo)
        {
            _mapper = mapper;
            _unitofwork = unitOfWork;
            _repo = repo;
        }
        [HttpPost("AddAttendace")]
        public async Task<IActionResult> AddAttendance(AttendanceResource AttendanceResource)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var AttendanceToAdd = _mapper.Map<AttendanceResource, Attendance>(AttendanceResource);
            _repo.AddAttendance(AttendanceToAdd);
            await _unitofwork.CompleteAsync();
            return StatusCode(201);
        }
        [HttpPost("AddAttendances")]
        public async Task<IActionResult> AddAttendances([FromBody]List<AttendanceResource> AttendanceResource)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var AttendanceToAdd = _mapper.Map<List<AttendanceResource>,List< Attendance>>(AttendanceResource);
            _repo.AddAttendance(AttendanceToAdd);
            await _unitofwork.CompleteAsync();
            return StatusCode(201);
        }
        [HttpGet("get")]

        public async Task<IEnumerable<AttendanceResource>> GetAttendance()
        {
            List<Attendance> Attendances = await _repo.GetAllAttendance();

            return _mapper.Map<List<Attendance>, List<AttendanceResource>>(Attendances);
        }
        [HttpPost(" GetAttendanceByEmployeeId")]
        public async Task<IEnumerable<AttendanceResource>> GetAttendanceByEmployeeId(int id)
        {
            var Attendances = await _repo.GetAttendanceByEmployee(id);

            return _mapper.Map<List<Attendance>, List<AttendanceResource>>(Attendances);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAttendacne(int id, [FromBody]AttendanceResource AttendanceResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Attendance attendance= await _repo.Get(id);
            if (attendance == null)
                return NotFound();
            _mapper.Map<AttendanceResource, Attendance>(AttendanceResource,attendance);
            await _unitofwork.CompleteAsync();
            return StatusCode(202);
        }



        [HttpDelete]
        public async Task<IActionResult> RemoveAttendance(int Id)
        {
            Attendance attendance = await _repo.Get(Id);
            _repo.RemoveAttendance(attendance);
            await _unitofwork.CompleteAsync();
            return Ok(Id);
        }

    }
}