using AutoMapper;
using Clinic.BLL.Interfaces;
using Clinic.DAL.Interfaces;

namespace Clinic.BLL.Services
{
    public class GenericService<TEntity, TModel> : IGenericService<TEntity, TModel> where TEntity : class
    {
        protected readonly IRepository<TEntity> _repository;
        protected readonly IMapper _mapper;

        public GenericService(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async virtual Task<TModel> CreateAsync(TModel model, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<TEntity>(model);
            var newEntity = await _repository.AddAsync(entity, cancellationToken);

            return _mapper.Map<TModel>(newEntity);
        }

        public async virtual Task<IEnumerable<TModel>> GetAllAsync(CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAllAsync(cancellationToken);

            return _mapper.Map<IEnumerable<TModel>>(entities);
        }

        public async virtual Task<TModel> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(id, cancellationToken);

            return _mapper.Map<TModel>(entity);
        }

        public async virtual Task<TModel> UpdateAsync(TModel model, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<TEntity>(model);
            var changedEntity = await _repository.UpdateAsync(entity, cancellationToken);

            return _mapper.Map<TModel>(changedEntity);
        }

        public async virtual Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(id, cancellationToken);
            await _repository.DeleteAsync(entity!, cancellationToken);
        }
    }
}
