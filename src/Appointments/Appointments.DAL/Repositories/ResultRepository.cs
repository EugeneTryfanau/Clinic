using Appointments.DAL.Entities;
using Appointments.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using StandartCRUD.StandartDAL;

namespace Appointments.DAL.Repositories
{
    public class ResultRepository(AppointmentDbContext appointmentDb) :
        Repository<ResultEntity, AppointmentDbContext>(appointmentDb),
        IResultRepository
    {
        public async Task<IEnumerable<ResultEntity>> GetAllAsync(Guid? appountmentId, CancellationToken cancellationToken)
        {
            IQueryable<ResultEntity> query = _dbContext.Results.AsQueryable();

            if (appountmentId != null)
            {
                query = query.Where(x => x.AppointmentId == appountmentId);
            }

            return await query.ToListAsync(cancellationToken);
        }
    }
}
