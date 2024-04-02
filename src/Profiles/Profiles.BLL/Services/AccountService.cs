using AutoMapper;
using Profiles.BLL.Interrfaces;
using Profiles.BLL.Models;
using Profiles.DAL.Entities;
using Profiles.DAL.Interfaces;

namespace Profiles.BLL.Services
{
    public class AccountService(IAccountRepository accountRepository, IMapper mapper) : 
        GenericService<AccountEntity, Account>(accountRepository, mapper), 
        IAccountService
    {
        private readonly IAccountRepository _accountRepository = accountRepository;

        public async Task<IEnumerable<Account>> GetAllAsync(string? email, string? phoneNumber, bool? isActive, CancellationToken cancellationToken)
        {
            var accounts = await _accountRepository.GetAllAsync(email, phoneNumber, isActive, cancellationToken);

            return _mapper.Map<IEnumerable<Account>>(accounts);
        }
    }
}
