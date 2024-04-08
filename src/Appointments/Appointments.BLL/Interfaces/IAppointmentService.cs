using Appointments.BLL.Models;
using StandartCRUD.StandartBLL;

namespace Appointments.BLL.Interfaces
{
    public interface IAppointmentService : IGenericService<Appointment>
    {
        Task<IEnumerable<Appointment>> GetAll(Guid? patientId, Guid? doctorId, Guid? serviceId,
            bool? isApproved, CancellationToken cancellationToken);
    }
}
