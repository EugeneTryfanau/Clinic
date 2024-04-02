using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Profiles.API.ViewModels.Account;
using Profiles.BLL.Interrfaces;

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
            var offices = await _accountService.GetAllAsync(email, phoneNumber, isActive, cancellationToken);

            return _mapper.Map<IEnumerable<AccountViewModel>>(offices);
        }
    }
}
