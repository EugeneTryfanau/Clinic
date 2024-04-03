using Profiles.BLL.Models;
using StandartCRUD.StandartBLL;

namespace Profiles.BLL.Interrfaces
{
    public interface ISpecializationService : IGenericService<Specialization>
    {
        Task<IEnumerable<Specialization>> GetAllAsync(string? specName, CancellationToken cancellationToken);
    }
}
