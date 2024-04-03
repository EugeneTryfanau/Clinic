﻿using Clinic.BLL.Models;
using Clinic.DAL.Entities;
using StandartCRUD.StandartBLL;

namespace Clinic.BLL.Interfaces
{
    public interface IOfficeService : IGenericService<OfficeEntity, Office>
    {
        Task<IEnumerable<Office>> GetAllAsync(string? address, string? phoneNumber, StandartStatus? isActive, CancellationToken cancellationToken);
    }
}
