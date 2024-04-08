using AutoMapper;
using Services.BLL.Interfaces;
using Services.BLL.Models;
using Services.DAL.Entities;
using Services.DAL.Interfaces;
using StandartCRUD.StandartBLL;

namespace Services.BLL.Services
{
    public class ServiceCategoryService(IServiceCategoryRepository serviceCategoryRepository, IMapper mapper) :
        GenericService<ServiceCategoryEntity, ServiceCategory>(serviceCategoryRepository, mapper),
        IServiceCategoryService
    {
        private readonly IServiceCategoryRepository _serviceCategoryRepository = serviceCategoryRepository;

        public async Task<IEnumerable<Service>> GetAllAsync(string? name, CancellationToken cancellationToken)
        {
            var services = await _serviceCategoryRepository.GetAllAsync(name, cancellationToken);

            return _mapper.Map<IEnumerable<Service>>(services);
        }
    }
}
