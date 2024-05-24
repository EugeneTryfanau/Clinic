using AutoMapper;
using Clinic.BLL.Interfaces;
using Clinic.BLL.Models;
using Clinic.DAL.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using StandartCRUD;

namespace Clinic.BLL.Services
{
    public class CacheOfficeService(IMemoryCache cache, IOfficeRepository repository, IMapper mapper) : ICacheOfficeService
    {
        public async Task<IEnumerable<Office>> TryGetOrCreateAsync(string? address, string? phoneNumber, StandartStatus? isActive, CancellationToken cancellationToken)
        {
            var cacheKey = $"Offices_{address}_{phoneNumber}_{isActive}";
            var cachedOffices = await cache.GetOrCreateAsync(cacheKey, async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);
                var offices = await repository.GetAllAsync(address, phoneNumber, isActive, cancellationToken);

                return mapper.Map<IEnumerable<Office>>(offices);
            });
            return cachedOffices!;
        }
    }
}
