using Documents.DAL.Entities;
using StandartCRUD.StandartDAL;

namespace Documents.DAL.Interfaces
{
    public interface IDocumentRepository : IRepository<DocumentEntity>
    {
        Task<IEnumerable<DocumentEntity>> GetAllAsync(Guid resultId, CancellationToken cancellationToken);
    }
}
