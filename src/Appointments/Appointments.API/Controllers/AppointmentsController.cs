using Appointments.API.ViewModels;
using Appointments.API.ViewModels.Appointment;
using Appointments.BLL.Interfaces;
using Appointments.BLL.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StandartCRUD.StandartAPI.Controllers;

namespace Appointments.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController(INotificationQueueService notificationQueueService, IAppointmentService appointmentService, IMapper mapper) :
        GenericController<Appointment, AppointmentViewModel>(appointmentService, mapper)
    {
        private readonly IAppointmentService _appointmentService = appointmentService;
        private readonly INotificationQueueService _queueService = notificationQueueService;

        [HttpGet]
        public async Task<IEnumerable<AppointmentViewModel>> GetAll([FromQuery] AppointmentSearchRequestData requestData, CancellationToken cancellationToken)
        {
            var appointments = await _appointmentService.GetAllAsync(requestData.PatientId, requestData.DoctorId, requestData.ServiceId, requestData.IsApproved, cancellationToken);

            return _mapper.Map<IEnumerable<AppointmentViewModel>>(appointments);
        }

        [HttpPost]
        public async override Task<AppointmentViewModel> Create(AppointmentViewModel viewModel, CancellationToken cancellationToken)
        {
            var result = await base.Create(viewModel, cancellationToken);
            _queueService.Enqueue(_mapper.Map<Appointment>(viewModel));
            return result;
        }
    }
}
