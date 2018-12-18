using System.Threading.Tasks;
using HR_DATA.HR_Module.Benefit;
using HR_DATA.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeBenefitsController : ControllerBase
    {
       
        private readonly IUnitOfWork _unitofwork; 
        private readonly IEmployeeBenefitRepository _repo;
      
        public EmployeeBenefitsController(IEmployeeBenefitRepository repo, IUnitOfWork unitOfWork)
        {
            _unitofwork = unitOfWork;
            _repo = repo;

        }
        [HttpPost("AddEmployeeBenefits")]
        public async Task<IActionResult> AddEmployeeBenefits(int employeeId, int benefitId)
        {
            //Employee employee = await _emprepo.Get(employeeId, includeRelated: false);
            //var Benefit = await _repo.Get(benefitId);
            var EmployeeBenefit = new EmployeeBenefits
            {
                EmployeeId = employeeId,
                BenefitId = benefitId
            };
            _repo.AddEmployeeBenefits(EmployeeBenefit);
            await _unitofwork.CompleteAsync();
            return StatusCode(201);
        }
        [HttpDelete("RemoveEmployeeBenefit")]
        public async Task<IActionResult> RemoveEmployeeBenefit(int EmployeeId,int BenefitId)
        {
           EmployeeBenefits employeeBenefits =await _repo.Get(BenefitId,EmployeeId);
            _repo.RemoveEmployeeBenefit(employeeBenefits);
           await _unitofwork.CompleteAsync();
            return Ok(EmployeeId);
        }

       
    } 
}