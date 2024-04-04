using Profiles.DAL.Entities;
using StandartCRUD.StandartDAL;

namespace Profiles.DAL.Interfaces
{
    public interface ISpecializationRepository : IRepository<SpecializationEntity>
    {
        Task<IEnumerable<SpecializationEntity>> GetAllAsync(string? specName, CancellationToken cancellationToken);
    }
}
