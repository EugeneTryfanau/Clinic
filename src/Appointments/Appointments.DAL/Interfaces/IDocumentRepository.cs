using Appointments.DAL.Entities;
using StandartCRUD.StandartDAL;

namespace Appointments.DAL.Interfaces
{
    public interface IDocumentRepository : IRepository<DocumentEntity>
    {
        Task<IEnumerable<DocumentEntity>> GetAll(Guid? resultId, CancellationToken cancellationToken);
    }
}
