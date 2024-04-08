using Appointments.DAL.Entities;
using Appointments.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using StandartCRUD.StandartDAL;

namespace Appointments.DAL.Repositories
{
    public class DocumentRepository(AppointmentDbContext appointmentDb) :
        Repository<DocumentEntity, AppointmentDbContext>(appointmentDb),
        IDocumentRepository
    {
        public async Task<IEnumerable<DocumentEntity>> GetAll(Guid? resultId, CancellationToken cancellationToken)
        {
            IQueryable<DocumentEntity> query = _dbContext.Documents.AsQueryable();

            if (resultId != null)
            {
                query = query.Where(x => x.ResultId == resultId);
            }

            return await query.ToListAsync(cancellationToken);
        }
    }
}
