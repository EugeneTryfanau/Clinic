﻿using Profiles.BLL.Models;
using Profiles.DAL.Entities;

namespace Profiles.BLL.Interrfaces
{
    public interface IAccountService : IGenericService<AccountEntity, Account>
    {
        Task<IEnumerable<Account>> GetAllAsync(string? email, string? phoneNumber, bool? isActive, CancellationToken cancellationToken);
    }
}
