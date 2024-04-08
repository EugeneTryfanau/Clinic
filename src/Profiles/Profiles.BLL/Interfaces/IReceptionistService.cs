using Profiles.BLL.Models;
using StandartCRUD.StandartBLL;

namespace Profiles.BLL.Interfaces
{
    public interface IReceptionistService : IGenericService<Receptionist>
    {
        Task<IEnumerable<Receptionist>> GetAllAsync(string? name, CancellationToken cancellationToken);
    }
}
