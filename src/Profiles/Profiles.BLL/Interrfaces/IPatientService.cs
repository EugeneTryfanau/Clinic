using Profiles.BLL.Models;
using Profiles.DAL.Entities;

namespace Profiles.BLL.Interrfaces
{
    public interface IPatientService : IGenericService<PatientEntity, Patient>
    {
        Task<IEnumerable<Patient>> GetAllAsync(string? name, CancellationToken cancellationToken);
    }
}
