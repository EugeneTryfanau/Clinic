using Profiles.DAL.Entities;

namespace Profiles.DAL.Interfaces
{
    public interface IAccountRepository : IRepository<AccountEntity>
    {
        Task<IEnumerable<AccountEntity>> GetAllAsync(string? email, string? phoneNumber, bool? isActive, CancellationToken cancellationToken);
    }
}
