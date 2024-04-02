using Profiles.DAL.Entities;

namespace Profiles.DAL.Interfaces
{
    public interface IDoctorRepository : IRepository<DoctorEntity>
    {
        Task<IEnumerable<DoctorEntity>> GetAllAsync(string? name, DoctorStatus? status, CancellationToken cancellationToken);
    }
}
