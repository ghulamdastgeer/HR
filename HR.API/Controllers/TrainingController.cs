using AutoMapper;
using HR.API.Controllers.Resources;
using HR_DATA.HR_Module.Training_Development;
using HR_DATA.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitofwork;
        private readonly ITrainingRepository _repo;
       
        public TrainingController(ITrainingRepository repo, IUnitOfWork unitofWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitofwork = unitofWork;
            _repo = repo;
        }
        [HttpPost]
        public async Task<IActionResult> AddTraining([FromBody]TrainingResource TrainingResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var TrainingToAdd = _mapper.Map<TrainingResource,Training>(TrainingResource);
            _repo.AddTrainings(TrainingToAdd);
            await _unitofwork.CompleteAsync();
            return StatusCode(201);
        }

        [HttpGet]
        public async Task<IEnumerable<TrainingResource>> GetTrainings()
        {
            List<Training> benefits = await _repo.GetAllTrainings();
            return _mapper.Map<List<Training>,List<TrainingResource>>(benefits);

        }


        [HttpDelete]
        public async Task<IActionResult> DeleteBenefit(int id)
        {
            Training training = await _repo.Get(id);
            _repo.RemoveTrainings(training);
            await _unitofwork.CompleteAsync();
            return Ok(id);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBenefits(int id, [FromBody] TrainingResource Trainingresource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Training Trainings = await _repo.Get(id);
            if (Trainings == null)
                return NotFound();
            _mapper.Map<TrainingResource,Training>(Trainingresource, Trainings);
            await _unitofwork.CompleteAsync();
            return StatusCode(202);
        }
    }
}