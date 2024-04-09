using Appointments.BLL.Interfaces;
using Appointments.BLL.Models;
using Appointments.DAL.Entities;
using Appointments.DAL.Interfaces;
using AutoMapper;
using StandartCRUD.StandartBLL;

namespace Appointments.BLL.Services
{
    public class AppointmentService(IAppointmentRepository appointmentRepository, IMapper mapper) :
        GenericService<AppointmentEntity, Appointment>(appointmentRepository, mapper),
        IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository = appointmentRepository;

        public async Task<IEnumerable<Appointment>> GetAllAsync(Guid? patientId, Guid? doctorId, Guid? serviceId, bool? isApproved, CancellationToken cancellationToken)
        {
            var appointments = await _appointmentRepository.GetAllAsync(patientId, doctorId, serviceId, isApproved, cancellationToken);

            return _mapper.Map<IEnumerable<Appointment>>(appointments);
        }
    }
}
