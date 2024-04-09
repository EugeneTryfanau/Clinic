using Appointments.BLL.Models;
using StandartCRUD.StandartBLL;

namespace Appointments.BLL.Interfaces
{
    public interface IAppointmentService : IGenericService<Appointment>
    {
        Task<IEnumerable<Appointment>> GetAllAsync(Guid? patientId, Guid? doctorId, Guid? serviceId,
            bool? isApproved, CancellationToken cancellationToken);
    }
}
