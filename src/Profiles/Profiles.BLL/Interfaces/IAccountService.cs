using Profiles.BLL.Models;
using StandartCRUD.StandartBLL;

namespace Profiles.BLL.Interfaces
{
    public interface IAccountService : IGenericService<Account>
    {
        Task<IEnumerable<Account>> GetAllAsync(string? email, string? phoneNumber, bool? isActive, CancellationToken cancellationToken);
    }
}
