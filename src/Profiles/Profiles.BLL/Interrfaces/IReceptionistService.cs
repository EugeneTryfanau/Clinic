using Profiles.BLL.Models;
using Profiles.DAL.Entities;

namespace Profiles.BLL.Interrfaces
{
    public interface IReceptionistService : IGenericService<ReceptionistEntity, Receptionist>
    {
        Task<IEnumerable<Receptionist>> GetAllAsync(string? name, CancellationToken cancellationToken);
    }
}
