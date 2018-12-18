using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HR_DATA.HR_Module.Benefit;
using HR_DATA.HR_Module.Organization;
using HR_DATA.HR_Module.Training_Development;
using HR_DATA.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeTrainingController : ControllerBase
    {
       
        private readonly IUnitOfWork _unitofwork;
        private readonly IEmployeeTrainingRepository _repo;
       
        public EmployeeTrainingController( IEmployeeTrainingRepository repo, IUnitOfWork unitOfWork)
        {
            _unitofwork = unitOfWork;
            _repo = repo;
        }

      
        [HttpPost]
        public async Task<IActionResult> AddEmployeeBenefits(int employeeId, int TrainingId)
        {
           
            var EmployeeTraining = new EmployeeTraining
            {
                EmployeeId = employeeId,
                TrainingsId=TrainingId
            };
            _repo.AddEmployeeTraining(EmployeeTraining);
            await _unitofwork.CompleteAsync();
            return StatusCode(201);
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveEmployeeBenefit(int EmployeeId, int TrainingId)
        {
            EmployeeTraining employeeTraining = await _repo.Get(EmployeeId, TrainingId);
            _repo.RemoveEmployeeTraining(employeeTraining);
            await _unitofwork.CompleteAsync();
            return Ok(EmployeeId);
        }


    }
}