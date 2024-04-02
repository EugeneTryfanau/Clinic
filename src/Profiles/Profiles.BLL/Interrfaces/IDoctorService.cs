using Profiles.BLL.Models;
using Profiles.DAL.Entities;

namespace Profiles.BLL.Interrfaces
{
    public interface IDoctorService : IGenericService<DoctorEntity, Doctor>
    {
        Task<IEnumerable<Doctor>> GetAllAsync(string? name, DoctorStatus? status, CancellationToken cancellationToken);
    }
}
