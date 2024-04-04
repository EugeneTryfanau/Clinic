using Profiles.BLL.Models;
using StandartCRUD.StandartBLL;

namespace Profiles.BLL.Interrfaces
{
    public interface IReceptionistService : IGenericService<Receptionist>
    {
        Task<IEnumerable<Receptionist>> GetAllAsync(string? name, CancellationToken cancellationToken);
    }
}
