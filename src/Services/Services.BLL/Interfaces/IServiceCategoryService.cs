using Services.BLL.Models;
using StandartCRUD.StandartBLL;

namespace Services.BLL.Interfaces
{
    public interface IServiceCategoryService : IGenericService<ServiceCategory>
    {
        Task<IEnumerable<Service>> GetAllAsync(string? name, CancellationToken cancellationToken);
    }
}
