using Appointments.BLL.Models;
using StandartCRUD.StandartBLL;

namespace Appointments.BLL.Interfaces
{
    public interface IResultService : IGenericService<Result>
    {
        Task<IEnumerable<Result>> GetAllAsync(Guid? appountmentId, CancellationToken cancellationToken);
    }
}
