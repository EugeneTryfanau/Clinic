using Profiles.BLL.Models;
using StandartCRUD;
using StandartCRUD.StandartBLL;

namespace Profiles.BLL.Interfaces
{
    public interface IDoctorService : IGenericService<Doctor>
    {
        Task<IEnumerable<Doctor>> GetAllAsync(string? name, DoctorStatus? status, CancellationToken cancellationToken);
    }
}
