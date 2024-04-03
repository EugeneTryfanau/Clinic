using Services.DAL.Entities;
using StandartCRUD;
using StandartCRUD.StandartDAL;

namespace Services.DAL.Interfaces
{
    public interface IServiceRepository : IRepository<ServiceEntity>
    {
        Task<IEnumerable<ServiceEntity>> GetAllAsync(string? name, StandartStatus? isActive, CancellationToken cancellationToken);
    }
}
