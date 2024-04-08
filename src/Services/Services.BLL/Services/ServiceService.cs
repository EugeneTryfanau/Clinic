using AutoMapper;
using Services.BLL.Interfaces;
using Services.BLL.Models;
using Services.DAL.Entities;
using Services.DAL.Interfaces;
using StandartCRUD;
using StandartCRUD.StandartBLL;

namespace Services.BLL.Services
{
    public class ServiceService(IServiceRepository serviceRepository, IMapper mapper) :
        GenericService<ServiceEntity, Service>(serviceRepository, mapper),
        IServiceService
    {
        private readonly IServiceRepository _serviceRepository = serviceRepository;

        public async Task<IEnumerable<Service>> GetAllAsync(string? name, StandartStatus? isActive, CancellationToken cancellationToken)
        {
            var services = await _serviceRepository.GetAllAsync(name, isActive, cancellationToken);

            return _mapper.Map<IEnumerable<Service>>(services);
        }
    }
}
