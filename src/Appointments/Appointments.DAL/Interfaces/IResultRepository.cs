using Appointments.DAL.Entities;
using StandartCRUD.StandartDAL;

namespace Appointments.DAL.Interfaces
{
    public interface IResultRepository : IRepository<ResultEntity>
    {
        Task<IEnumerable<ResultEntity>> GetAllAsync(Guid? appountmentId, CancellationToken cancellationToken);
    }
}
