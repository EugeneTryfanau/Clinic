using Appointments.DAL.Entities;
using Appointments.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using StandartCRUD.StandartDAL;

namespace Appointments.DAL.Repositories
{
    public class AppointmentRepository(AppointmentDbContext appointmentDb) :
        Repository<AppointmentEntity, AppointmentDbContext>(appointmentDb),
        IAppointmentRepository
    {
        public async Task<IEnumerable<AppointmentEntity>> GetAll(Guid? patientId, Guid? doctorId, Guid? serviceId, bool? isApproved, CancellationToken cancellationToken)
        {
            IQueryable<AppointmentEntity> query = _dbContext.Appointments.AsQueryable();

            if (patientId != null)
            {
                query = query.Where(x => x.PatientId == patientId);
            }

            if (doctorId != null)
            {
                query = query.Where(x => x.DoctorId == doctorId);
            }

            if (serviceId != null)
            {
                query = query.Where(x => x.ServiceId == serviceId);
            }

            if (isApproved != null)
            {
                query = query.Where(x => x.IsApproved == isApproved);
            }

            return await query.ToListAsync(cancellationToken);
        }
    }
}
