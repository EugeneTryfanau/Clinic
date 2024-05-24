using AutoMapper;
using Clinic.BLL.Interfaces;
using Clinic.BLL.Models;
using Clinic.DAL.Entities;
using Clinic.DAL.Interfaces;
using StandartCRUD;
using StandartCRUD.StandartBLL;

namespace Clinic.BLL.Services
{
    public class OfficeService(IOfficeRepository officeRepository, IMapper mapper, ICacheOfficeService cacheService) :
        GenericService<OfficeEntity, Office>(officeRepository, mapper),
        IOfficeService
    {
        public async Task<IEnumerable<Office>> GetAllAsync(string? address, string? phoneNumber, StandartStatus? isActive, CancellationToken cancellationToken)
        {
            return await cacheService.TryGetOrCreateAsync(address, phoneNumber, isActive, cancellationToken);
        }
    }
}
