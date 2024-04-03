using Profiles.DAL.Entities;
using StandartCRUD.StandartDAL;

namespace Profiles.DAL.Interfaces
{
    public interface IPatientRepository : IRepository<PatientEntity>
    {
        Task<IEnumerable<PatientEntity>> GetAllAsync(string? name, CancellationToken cancellationToken);
    }
}
