using AutoMapper;
using Clinic.BLL.Interfaces;
using Clinic.BLL.Models;
using Clinic.DAL.Entities;
using Clinic.DAL.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using StandartCRUD;
using StandartCRUD.StandartBLL;

namespace Clinic.BLL.Services
{
    public class OfficeService(IOfficeRepository officeRepository, IMapper mapper, IMemoryCache cache) :
        GenericService<OfficeEntity, Office>(officeRepository, mapper),
        IOfficeService
    {
        private readonly IMemoryCache _cache = cache;

        public async Task<IEnumerable<Office>> GetAllAsync(string? address, string? phoneNumber, StandartStatus? isActive, CancellationToken cancellationToken)
        {

            var cacheKey = $"Offices_{address}_{phoneNumber}_{isActive}";
            var cachedOffices = await _cache.GetOrCreateAsync(cacheKey, async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);
                var offices = await officeRepository.GetAllAsync(address, phoneNumber, isActive, cancellationToken);

                return _mapper.Map<IEnumerable<Office>>(offices);
            });

            return cachedOffices!;
        }
    }
}
