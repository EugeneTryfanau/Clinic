﻿using Clinic.DAL.Entities;
using Clinic.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using StandartCRUD;
using StandartCRUD.StandartDAL;

namespace Clinic.DAL.Repositories
{
    public class OfficeRepository(ClinicDbContext dbContext) : 
        Repository<OfficeEntity, ClinicDbContext>(dbContext), 
        IOfficeRepository
    {
        public async Task<IEnumerable<OfficeEntity>> GetAllAsync(string? address, string? phoneNumber, StandartStatus? isActive, CancellationToken cancellationToken)
        {
            IQueryable<OfficeEntity> query = _dbContext.Offices.AsQueryable();

            if (!string.IsNullOrWhiteSpace(address))
            {
                var addressLower = address.ToLower();
                query = query.Where(x => EF.Functions.Like(x.Address.ToLower(), $"%{addressLower}%"));
            }

            if (!string.IsNullOrWhiteSpace(phoneNumber))
            {
                query = query.Where(x => EF.Functions.Like(x.RegistryPhoneNumber, $"%{phoneNumber}%"));
            }

            if (isActive != null)
            {
                query = query.Where(x => x.IsActive == isActive);
            }

            return await query.ToListAsync(cancellationToken);
        }
    }
}
