using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StandartCRUD.StandartBLL;
using StandartCRUD.StandartBLL.Models;

namespace StandartCRUD.StandartAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController<TModel, TViewModel>
        (IGenericService<TModel> genericService, IMapper mapper) : ControllerBase
        where TModel : BaseModel
        where TViewModel : class
    {
        protected readonly IGenericService<TModel> _genericService = genericService;
        protected readonly IMapper _mapper = mapper;

        [HttpGet("{id}")]
        public async virtual Task<TViewModel> GetById(Guid id, CancellationToken cancellationToken)
        {
            var model = await _genericService.GetByIdAsync(id, cancellationToken);

            return _mapper.Map<TViewModel>(model);
        }

        [HttpPost]
        public async virtual Task<TViewModel> Create(TViewModel viewModel, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<TModel>(viewModel);
            model.Id = Guid.Empty;
            var result = await _genericService.CreateAsync(model, cancellationToken);

            return _mapper.Map<TViewModel>(result);
        }

        [HttpPut("{id}")]
        public async virtual Task<TViewModel> Update(Guid id, TViewModel viewModel, CancellationToken cancellationToken)
        {
            var modelToUpdate = _mapper.Map<TModel>(viewModel);
            modelToUpdate.Id = id;
            var result = await _genericService.UpdateAsync(modelToUpdate, cancellationToken);

            return _mapper.Map<TViewModel>(result);
        }

        [HttpDelete("{id}")]
        public async virtual Task Delete(Guid id, CancellationToken cancellationToken)
        {
            await _genericService.DeleteAsync(id, cancellationToken);
        }
    }
}
