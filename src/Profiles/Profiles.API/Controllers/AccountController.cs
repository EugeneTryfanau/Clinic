using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Profiles.API.ViewModels.Account;
using Profiles.BLL.Interrfaces;
using Profiles.BLL.Models;

namespace Profiles.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(IAccountService accountService, IMapper mapper) : ControllerBase
    {
        private readonly IAccountService _accountService = accountService;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public async Task<IEnumerable<AccountViewModel>> GetAll(string? email, string? phoneNumber, bool? isActive, CancellationToken cancellationToken)
        {
            var accounts = await _accountService.GetAllAsync(email, phoneNumber, isActive, cancellationToken);

            return _mapper.Map<IEnumerable<AccountViewModel>>(accounts);
        }

        [HttpGet("{id}")]
        public async Task<AccountViewModel> GetById(Guid id, CancellationToken cancellationToken)
        {
            var account = await _accountService.GetByIdAsync(id, cancellationToken);

            return _mapper.Map<AccountViewModel>(account);
        }

        [HttpPost]
        public async Task<AccountViewModel> Create(CreateAccountViewModel viewModel, CancellationToken cancellationToken)
        {
            var account = _mapper.Map<Account>(viewModel);
            var result = await _accountService.CreateAsync(account, cancellationToken);

            return _mapper.Map<AccountViewModel>(result);
        }

        [HttpPut("{id}")]
        public async Task<AccountViewModel> Update(Guid id, UpdateAccountViewModel viewModel, CancellationToken cancellationToken)
        {
            var modelToUpdate = _mapper.Map<Account>(viewModel);
            modelToUpdate.Id = id;
            var result = await _accountService.UpdateAsync(modelToUpdate, cancellationToken);

            return _mapper.Map<AccountViewModel>(result);
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id, CancellationToken cancellationToken)
        {
            await _accountService.DeleteAsync(id, cancellationToken);
        }
    }
}
