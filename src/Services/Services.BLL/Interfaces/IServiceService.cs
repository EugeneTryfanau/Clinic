using Services.BLL.Models;
using StandartCRUD;
using StandartCRUD.StandartBLL;

namespace Services.BLL.Interfaces
{
    public interface IServiceService : IGenericService<Service>
    {
        Task<IEnumerable<Service>> GetAllAsync(string? name, StandartStatus? isActive, CancellationToken cancellationToken);
    }
}
