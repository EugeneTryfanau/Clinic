using AutoMapper;
using Clinic.BLL.Interfaces;
using Clinic.BLL.Models;
using Clinic.DAL.Entities;
using Clinic.DAL.Interfaces;

namespace Clinic.BLL.Services
{
    public class OfficeService : GenericService<OfficeEntity, Office>, IOfficeService
    {
        private readonly IOfficeRepository _officeRepository;

        public OfficeService(IOfficeRepository officeRepository, IMapper mapper) : base(officeRepository, mapper)
        {
            _officeRepository = officeRepository;
        }

        public async Task<IEnumerable<Office>> GetAllAsync(string? address, string? phoneNumber, StandartStatus? isActive, CancellationToken cancellationToken)
        {
            var offices = await _officeRepository.GetAllAsync(address, phoneNumber, isActive, cancellationToken);

            return _mapper.Map<IEnumerable<Office>>(offices);
        }
    }
}
