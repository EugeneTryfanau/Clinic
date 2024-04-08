using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Profiles.API.ViewModels;
using Profiles.API.ViewModels.Patient;
using Profiles.BLL.Interfaces;
using Profiles.BLL.Models;

namespace Profiles.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController(IPatientService patientService, IMapper mapper) : ControllerBase
    {
        private readonly IPatientService _patientService = patientService;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public async Task<IEnumerable<PatientViewModel>> GetAll([FromQuery]ProfileSearchRequestData requestData, CancellationToken cancellationToken)
        {
            var patients = await _patientService.GetAllAsync(requestData.Name, cancellationToken);

            return _mapper.Map<IEnumerable<PatientViewModel>>(patients);
        }

        [HttpGet("{id}")]
        public async Task<PatientViewModel> GetById(Guid id, CancellationToken cancellationToken)
        {
            var patient = await _patientService.GetByIdAsync(id, cancellationToken);

            return _mapper.Map<PatientViewModel>(patient);
        }

        [HttpPost]
        public async Task<PatientViewModel> Create(CreatePatientViewModel viewModel, CancellationToken cancellationToken)
        {
            var patient = _mapper.Map<Patient>(viewModel);
            var result = await _patientService.CreateAsync(patient, cancellationToken);

            return _mapper.Map<PatientViewModel>(result);
        }

        [HttpPut("{id}")]
        public async Task<PatientViewModel> Update(Guid id, UpdatePatientViewModel viewModel, CancellationToken cancellationToken)
        {
            var modelToUpdate = _mapper.Map<Patient>(viewModel);
            modelToUpdate.Id = id;
            var result = await _patientService.UpdateAsync(modelToUpdate, cancellationToken);

            return _mapper.Map<PatientViewModel>(result);
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id, CancellationToken cancellationToken)
        {
            await _patientService.DeleteAsync(id, cancellationToken);
        }
    }
}
