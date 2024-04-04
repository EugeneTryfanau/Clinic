using AutoMapper;
using Clinic.BLL.Interfaces;
using Clinic.BLL.Models;
using Clinic.DAL.Entities;
using Clinic.DAL.Interfaces;
using StandartCRUD.StandartBLL;

namespace Clinic.BLL.Services
{
    public class OfficeService(IOfficeRepository officeRepository, IMapper mapper) : 
        GenericService<OfficeEntity, Office>(officeRepository, mapper), 
        IOfficeService
    {
        private readonly IOfficeRepository _officeRepository = officeRepository;

        public async Task<IEnumerable<Office>> GetAllAsync(string? address, string? phoneNumber, StandartStatus? isActive, CancellationToken cancellationToken)
        {
            var offices = await _officeRepository.GetAllAsync(address, phoneNumber, isActive, cancellationToken);

            return _mapper.Map<IEnumerable<Office>>(offices);
        }
    }
}
