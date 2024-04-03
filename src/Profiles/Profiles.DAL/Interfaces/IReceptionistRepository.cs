using Profiles.DAL.Entities;
using StandartCRUD.StandartDAL;

namespace Profiles.DAL.Interfaces
{
    public interface IReceptionistRepository : IRepository<ReceptionistEntity>
    {
        Task<IEnumerable<ReceptionistEntity>> GetAllAsync(string? name, CancellationToken cancellationToken);
    }
}
