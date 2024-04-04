using Profiles.DAL.Entities;
using StandartCRUD.StandartDAL;

namespace Profiles.DAL.Interfaces
{
    public interface IAccountRepository : IRepository<AccountEntity>
    {
        Task<IEnumerable<AccountEntity>> GetAllAsync(string? email, string? phoneNumber, bool? isActive, CancellationToken cancellationToken);
    }
}
