﻿namespace StandartCRUD.StandartBLL
{
    public interface IGenericService<TModel>
    {
        Task<TModel> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<TModel> CreateAsync(TModel model, CancellationToken cancellationToken);
        Task<TModel> UpdateAsync(TModel model, CancellationToken cancellationToken);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<TModel>> GetAllAsync(CancellationToken cancellationToken);
    }
}
