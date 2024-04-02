using Profiles.DAL.Entities;

namespace Profiles.DAL.Interfaces
{
    public interface IReceptionistRepository : IRepository<ReceptionistEntity>
    {
        Task<IEnumerable<ReceptionistEntity>> GetAllAsync(string? name, CancellationToken cancellationToken);
    }
}
