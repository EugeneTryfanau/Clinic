using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Profiles.API.ViewModels;
using Profiles.API.ViewModels.Doctor;
using Profiles.BLL.Interfaces;
using Profiles.BLL.Models;

namespace Profiles.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController(IDoctorService doctorService, IMapper mapper) : ControllerBase
    {
        private readonly IDoctorService _doctorService = doctorService;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public async Task<IEnumerable<DoctorViewModel>> GetAll([FromQuery]ProfileSearchRequestData requestData, CancellationToken cancellationToken)
        {
            var doctors = await _doctorService.GetAllAsync(requestData.Name, requestData.DoctorStatus, cancellationToken);

            return _mapper.Map<IEnumerable<DoctorViewModel>>(doctors);
        }

        [HttpGet("{id}")]
        public async Task<DoctorViewModel> GetById(Guid id, CancellationToken cancellationToken)
        {
            var doctor = await _doctorService.GetByIdAsync(id, cancellationToken);

            return _mapper.Map<DoctorViewModel>(doctor);
        }

        [HttpPost]
        public async Task<DoctorViewModel> Create(CreateDoctorViewModel viewModel, CancellationToken cancellationToken)
        {
            var doctor = _mapper.Map<Doctor>(viewModel);
            var result = await _doctorService.CreateAsync(doctor, cancellationToken);

            return _mapper.Map<DoctorViewModel>(result);
        }

        [HttpPut("{id}")]
        public async Task<DoctorViewModel> Update(Guid id, UpdateDoctorViewModel viewModel, CancellationToken cancellationToken)
        {
            var modelToUpdate = _mapper.Map<Doctor>(viewModel);
            modelToUpdate.Id = id;
            var result = await _doctorService.UpdateAsync(modelToUpdate, cancellationToken);

            return _mapper.Map<DoctorViewModel>(result);
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id, CancellationToken cancellationToken)
        {
            await _doctorService.DeleteAsync(id, cancellationToken);
        }
    }
}
