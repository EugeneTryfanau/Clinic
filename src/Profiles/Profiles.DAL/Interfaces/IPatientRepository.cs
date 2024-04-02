using Profiles.DAL.Entities;

namespace Profiles.DAL.Interfaces
{
    public interface IPatientRepository : IRepository<PatientEntity>
    {
        Task<IEnumerable<PatientEntity>> GetAllAsync(string? name, CancellationToken cancellationToken);
    }
}
