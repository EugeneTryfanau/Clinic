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
    public class AppointmentController(IAppointmentService appointmentService, IMapper mapper) : 
        GenericController<Appointment,AppointmentViewModel, CreateAppointmentViewModel, UpdateAppointmentViewModel>(appointmentService, mapper)
    {
        private readonly IAppointmentService _appointmentService = appointmentService;

        [HttpGet]
        public async Task<IEnumerable<AppointmentViewModel>> GetAll([FromQuery] AppointmentSearchRequestData requestData, CancellationToken cancellationToken)
        {
            var appointments = await _appointmentService.GetAllAsync(requestData.PatientId, requestData.DoctorId, requestData.ServiceId, requestData.IsApproved, cancellationToken);

            return _mapper.Map<IEnumerable<AppointmentViewModel>>(appointments);
        }
    }
}
