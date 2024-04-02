using Microsoft.EntityFrameworkCore;
using Profiles.DAL.Entities;
using Profiles.DAL.Interfaces;

namespace Profiles.DAL.Repositories
{
    public class AccountRepository : Repository<AccountEntity>, IAccountRepository
    {
        public AccountRepository(ProfilesDbContext dbContext) : base(dbContext) { }

        public async Task<IEnumerable<AccountEntity>> GetAllAsync(string? email, string? phoneNumber, bool? isActive, CancellationToken cancellationToken)
        {
            IQueryable<AccountEntity> query = _dbContext.Accounts.AsQueryable();

            if (!string.IsNullOrWhiteSpace(email))
            {
                var emailLower = email.ToLower();
                query = query.Where(x => EF.Functions.Like(x.Email.ToLower(), $"%{emailLower}%"));
            }

            if (!string.IsNullOrWhiteSpace(phoneNumber))
            {
                query = query.Where(x => EF.Functions.Like(x.PhoneNumber, $"%{phoneNumber}%"));
            }

            if (isActive != null)
            {
                query = query.Where(x => x.IsActive == isActive);
            }

            return await query.ToListAsync(cancellationToken);
        }
    }
}
