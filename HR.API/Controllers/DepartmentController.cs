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
    public class DepartmentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitofwork;
        private readonly IDepartmentRepository _repo;
        public DepartmentController(IDepartmentRepository repo,IUnitOfWork unitOfWork,IMapper mapper )
        {
            _mapper = mapper;
            _unitofwork = unitOfWork;
            _repo = repo;
        }
        [HttpPost("add-dept")]

        public async Task<IActionResult> AddDept([FromBody]SaveDepartmentResource DepartmentResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var DeptToCreate = _mapper.Map<SaveDepartmentResource, Departments>(DepartmentResource);
            _repo.CreateDept(DeptToCreate);
            await _unitofwork.CompleteAsync();
            return StatusCode(201);
        }

        [HttpGet("Get_depts")]

        public async Task<IEnumerable<DepartmentsResource>> GetDepartments()
        {
            List<Departments> depts = await _repo.GetAllDepartments();
     
            return _mapper.Map<List<Departments>, List<DepartmentsResource>>(depts);
        }

        [HttpDelete("delete-dept")]
        public async Task<ActionResult> DeleteDept(int id)
        {
            Departments dept= await _repo.Get(id);
            _repo.RemoveDept(dept);
            await _unitofwork.CompleteAsync();
            return Ok(id);
        }
         [HttpGet("GetDeptById")]
        public async Task<DepartmentsResource> GetDept(int id)
        {
            Departments dept= await _repo.Get(id);
            return _mapper.Map<Departments,DepartmentsResource>(dept);
                    
        }

        [HttpPut("update-dept")]
        public async Task<IActionResult> UpdateBranch(int id,[FromBody]SaveDepartmentResource DepartmentResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Departments departments = await _repo.Get(id);
            if (departments == null)
                return NotFound();
            _mapper.Map<SaveDepartmentResource, Departments>(DepartmentResource, departments);
            await _unitofwork.CompleteAsync();
            return StatusCode(202);
        }
    }
}