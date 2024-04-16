using Documents.BLL.Models;
using StandartCRUD.StandartBLL;

namespace Documents.BLL.Interfaces
{
    public interface IDocumentService : IGenericService<Document>
    {
        Task<IEnumerable<Document>> GetAllAsync(Guid resultId, CancellationToken cancellationToken);
    }
}
