using AutoMapper;
using Profiles.BLL.Interrfaces;
using Profiles.BLL.Models;
using Profiles.DAL.Entities;
using Profiles.DAL.Interfaces;

namespace Profiles.BLL.Services
{
    public class AccountService : GenericService<AccountEntity, Account>, IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository, IMapper mapper) : base(accountRepository, mapper)
        {
            _accountRepository = accountRepository;
        }

        public async Task<IEnumerable<Account>> GetAllAsync(string? email, string? phoneNumber, bool? isActive, CancellationToken cancellationToken)
        {
            var accounts = await _accountRepository.GetAllAsync(email, phoneNumber, isActive, cancellationToken);

            return _mapper.Map<IEnumerable<Account>>(accounts);
        }
    }
}
