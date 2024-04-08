using Appointments.API.ViewModels;
using Appointments.API.ViewModels.Appointment;
using Appointments.BLL.Interfaces;
using Appointments.BLL.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Appointments.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController(IAppointmentService appointmentService, IMapper mapper) : ControllerBase
    {
        private readonly IAppointmentService _appointmentService = appointmentService;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public async Task<IEnumerable<AppointmentViewModel>> GetAll([FromQuery] AppointmentSearchRequestData requestData, CancellationToken cancellationToken)
        {
            var appointments = await _appointmentService.GetAllAsync(requestData.PatientId, requestData.DoctorId, requestData.ServiceId, requestData.IsApproved, cancellationToken);

            return _mapper.Map<IEnumerable<AppointmentViewModel>>(appointments);
        }

        [HttpGet("{id}")]
        public async Task<AppointmentViewModel> GetById(Guid id, CancellationToken cancellationToken)
        {
            var appointment = await _appointmentService.GetByIdAsync(id, cancellationToken);

            return _mapper.Map<AppointmentViewModel>(appointment);
        }

        [HttpPost]
        public async Task<AppointmentViewModel> Create(CreateAppointmentViewModel viewModel, CancellationToken cancellationToken)
        {
            var appointment = _mapper.Map<Appointment>(viewModel);
            var result = await _appointmentService.CreateAsync(appointment, cancellationToken);

            return _mapper.Map<AppointmentViewModel>(result);
        }

        [HttpPut("{id}")]
        public async Task<AppointmentViewModel> Update(Guid id, UpdateAppointmentViewModel viewModel, CancellationToken cancellationToken)
        {
            var modelToUpdate = _mapper.Map<Appointment>(viewModel);
            modelToUpdate.Id = id;
            var result = await _appointmentService.UpdateAsync(modelToUpdate, cancellationToken);

            return _mapper.Map<AppointmentViewModel>(result);
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id, CancellationToken cancellationToken)
        {
            await _appointmentService.DeleteAsync(id, cancellationToken);
        }
    }
}
