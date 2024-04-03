using Profiles.BLL.Models;
using Profiles.DAL.Entities;
using StandartCRUD.StandartBLL;

namespace Profiles.BLL.Interrfaces
{
    public interface IPatientService : IGenericService<PatientEntity, Patient>
    {
        Task<IEnumerable<Patient>> GetAllAsync(string? name, CancellationToken cancellationToken);
    }
}
