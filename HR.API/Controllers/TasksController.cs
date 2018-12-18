using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HR.API.Controllers.Resources;
using HR_DATA.HR_Module.BusinessGoals;
using HR_DATA.HR_Module.Recruitement;
using HR_DATA.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitofwork;
        private readonly ITaskRepository _repo;

        public TasksController(ITaskRepository repo, IUnitOfWork unitofWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitofwork = unitofWork;
            _repo = repo;
        }
        [HttpPost("AddTasks")]
        public async Task<IActionResult> AddTasks([FromBody]EmployeeTasksResources TasksResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var TaskToAdd = _mapper.Map<EmployeeTasksResources, EmployeeTasks>(TasksResource);
            _repo.AddTasks(TaskToAdd);
            await _unitofwork.CompleteAsync();
            return StatusCode(201);
        }

        [HttpGet("GetTasks")]
        public async Task<IEnumerable<EmployeeTasksResources>> GetTasks()
        {
            var Tasks = await _repo.GetAllTasks();
            return _mapper.Map<List<EmployeeTasks>, List<EmployeeTasksResources>>(Tasks);

        }


        [HttpDelete("DeleteTask")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            EmployeeTasks Tasks = await _repo.Get(id);
            _repo.RemoveTasks(Tasks);
            await _unitofwork.CompleteAsync();
            return Ok(id);
        }

        [HttpPut("UpdateTasks")]
        public async Task<IActionResult> UpdateTasks(int id, [FromBody] EmployeeTasksResources TaskResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            EmployeeTasks Tasks = await _repo.Get(id);
            if (Tasks == null)
                return NotFound();
            _mapper.Map(TaskResource, Tasks);
            await _unitofwork.CompleteAsync();
            return StatusCode(202);
        }
    }
}