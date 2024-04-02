using Profiles.BLL.Models;
using Profiles.DAL.Entities;

namespace Profiles.BLL.Interrfaces
{
    public interface ISpecializationService : IGenericService<SpecializationEntity, Specialization>
    {
        Task<IEnumerable<Specialization>> GetAllAsync(string? specName, CancellationToken cancellationToken);
    }
}
