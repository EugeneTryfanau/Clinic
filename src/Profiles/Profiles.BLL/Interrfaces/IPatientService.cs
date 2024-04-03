using Profiles.BLL.Models;
using StandartCRUD.StandartBLL;

namespace Profiles.BLL.Interrfaces
{
    public interface IPatientService : IGenericService<Patient>
    {
        Task<IEnumerable<Patient>> GetAllAsync(string? name, CancellationToken cancellationToken);
    }
}
