using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HR.API.Controllers.Resources;
using HR.API.Helper;
using HR_DATA.Helper;
using HR_DATA.HR_Module;
using HR_DATA.HR_Module.Organization;
using HR_DATA.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitofwork;
        private readonly IEmployeeRepository _repo;
        public EmployeeController(IEmployeeRepository repo,IUnitOfWork unitOfWork,IMapper mapper)
        {
            _repo = repo;
            _unitofwork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost("Add-Employee")]

        public async Task<IActionResult> AddEmployee([FromBody]SaveEmployeeResource EmployeeResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var EmployeeToCreate = _mapper.Map<SaveEmployeeResource, Employee>(EmployeeResource);
            _repo.CreateEmployee(EmployeeToCreate);
            await _unitofwork.CompleteAsync();
            return StatusCode(201);
        }
        [HttpGet("GetEmployees")]
        public async Task<IEnumerable<EmployeeResource>> GetEmployees([FromQuery]EmployeeParams Params )
        {
           
            var Employee = await _repo.GetAllEmployees(Params);
            var Employees= _mapper.Map<List<EmployeeResource>>(Employee);
            Response.AddPagination(Employee.CurrentPage, Employee.PageSize, 
                Employee.TotalCount, Employee.TotalPages);
            return Employees;
        }
         [HttpGet("GetEmployeeById")]
        public async Task<EmployeeResource> GetEmployee(int id)
        {
            Employee Employees = await _repo.Get(id);
            return _mapper.Map<Employee,EmployeeResource>(Employees);

        }

        [HttpDelete("DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            Employee employee = await _repo.Get(id);
            _repo.RemoveEmployee(employee);
            await _unitofwork.CompleteAsync();
            return Ok(id);
        }

        [HttpPut("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee(int id,[FromBody] SaveEmployeeResource EmployeeResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

           Employee employee = await _repo.Get(id);
            if (employee == null)
                return NotFound();
            _mapper.Map<SaveEmployeeResource, Employee>(EmployeeResource, employee);
            await _unitofwork.CompleteAsync();
            return StatusCode(202);
        }
    }
}