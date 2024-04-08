using Profiles.BLL.Models;
using StandartCRUD.StandartBLL;

namespace Profiles.BLL.Interfaces
{
    public interface ISpecializationService : IGenericService<Specialization>
    {
        Task<IEnumerable<Specialization>> GetAllAsync(string? specName, CancellationToken cancellationToken);
    }
}
