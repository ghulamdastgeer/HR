using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HR.API.Controllers.Resources;
using HR_DATA.HR_Module.Attendance_Leave;
using HR_DATA.HR_Module.BusinessGoals;
using HR_DATA.HR_Module.EmployeePerformances;
using HR_DATA.HR_Module.Recruitement;
using HR_DATA.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static HR_DATA.HR_Module.DataUtils;

namespace HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerformanceController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitofwork;
        private readonly IEmployeePerformanceRepository _repo;
        private readonly IAttendanceRepository _arepo;
        private readonly ITaskRepository _trepo;

        public PerformanceController(IEmployeePerformanceRepository repo,ITaskRepository trepo,IAttendanceRepository arepo, IUnitOfWork unitofWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitofwork = unitofWork;
            _repo = repo;
            _arepo = arepo;
            _trepo = trepo;
        }
        [HttpPost("AddPerformance")]
        public async Task<IActionResult> AddPerformance([FromBody]EmployeePerformanceResource PerformanceResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var attendance = await _arepo.GetAttendance(PerformanceResource.EmployeeId);

            var total_attendance = await _arepo.GetAttendanceByEmployee(PerformanceResource.EmployeeId);

            int employee_attendance = total_attendance.Count;
            int teattendance = attendance.Count;
            var Deadline = await _trepo.GetDeadline();
            int deadlinemeet = Deadline.Count;

            var tasksCompleted = await _trepo.TaskStatus();
            PerformanceResource.Performance.TaskCompleted = tasksCompleted.Count;
           
           
            int behaviourmarks = 0;

            if (PerformanceResource.Performance.Behaviour == Behaviour.Aggresive)
                behaviourmarks = 50;
            else if (PerformanceResource.Performance.Behaviour == Behaviour.Assertive)
                behaviourmarks = 70;
            else if (PerformanceResource.Performance.Behaviour == Behaviour.Passive)
                behaviourmarks = 80;
            double punctual =   teattendance/employee_attendance;
            float punctualper =(float)punctual* 100;
            PerformanceResource.Performance.Punctual = punctualper;
            var tasks = await _trepo.GetTaskByEmployeeId(PerformanceResource.EmployeeId);
            var totaltasks = tasks.Count;
            float performance = (( behaviourmarks/100 +  punctualper/100) * 30 + (tasksCompleted.Count / totaltasks) * 50 + (deadlinemeet / tasksCompleted.Count) * 20);

            PerformanceResource.PerformacePercentage = performance;
                
            var PerformanceToAdd = _mapper.Map<EmployeePerformanceResource, EmployeePerformance>(PerformanceResource);
            _repo.CaculatePerformance(PerformanceToAdd);
            await _unitofwork.CompleteAsync();
            return StatusCode(201);
        }

        [HttpGet("GetPerformances")]
        public async Task<IEnumerable<PerformanceResource>> GetPerformances()
        {
            List<Performance> performances = await _repo.GetAllPerformances();
            return _mapper.Map<List<Performance>, List<PerformanceResource>>(performances);

        }


        [HttpDelete("DeletePerformance")]
        public async Task<IActionResult> DeletePerformance(int id)
        {
            Performance performance = await _repo.Get(id);
            _repo.Removeperformance(performance);
            await _unitofwork.CompleteAsync();
            return Ok(id);
        }

        [HttpPut("UpdatePerformance")]
        public async Task<IActionResult> UpdatePerformance(int id, [FromBody] PerformanceResource PerformanceResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Performance performance = await _repo.Get(id);
            if (performance == null)
                return NotFound();
            _mapper.Map<PerformanceResource, Performance>(PerformanceResource, performance);
            await _unitofwork.CompleteAsync();
            return StatusCode(202);
        }
    }
}