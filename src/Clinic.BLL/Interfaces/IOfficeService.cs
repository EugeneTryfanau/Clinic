﻿using Clinic.BLL.Models;
using StandartCRUD;
using StandartCRUD.StandartBLL;

namespace Clinic.BLL.Interfaces
{
    public interface IOfficeService : IGenericService<Office>
    {
        Task<IEnumerable<Office>> GetAllAsync(string? address, string? phoneNumber, StandartStatus? isActive, CancellationToken cancellationToken);
    }
}
