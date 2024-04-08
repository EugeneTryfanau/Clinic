using Appointments.BLL.Models;
using StandartCRUD.StandartBLL;

namespace Appointments.BLL.Interfaces
{
    public interface IDocumentService : IGenericService<Document>
    {
        Task<IEnumerable<Document>> GetAll(Guid? resultId, CancellationToken cancellationToken);
    }
}
