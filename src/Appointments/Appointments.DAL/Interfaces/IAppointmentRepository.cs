using Appointments.DAL.Entities;
using StandartCRUD.StandartDAL;

namespace Appointments.DAL.Interfaces
{
    public interface IAppointmentRepository : IRepository<AppointmentEntity>
    {
        Task<IEnumerable<AppointmentEntity>> GetAll(Guid? patientId, Guid? doctorId, Guid? serviceId,
            bool? isApproved, CancellationToken cancellationToken);
    }
}
