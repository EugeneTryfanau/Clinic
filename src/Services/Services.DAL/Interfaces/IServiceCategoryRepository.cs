using Services.DAL.Entities;
using StandartCRUD.StandartDAL;

namespace Services.DAL.Interfaces
{
    public interface IServiceCategoryRepository : IRepository<ServiceCategoryEntity>
    {
        Task<IEnumerable<ServiceEntity>> GetAllAsync(string? name, CancellationToken cancellationToken);
    }
}
