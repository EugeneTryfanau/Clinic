using Clinic.DAL.Entities;
using Clinic.DAL.Interfaces;
using StandartCRUD;

namespace Clinic.IntegrationTests.TestData.Services
{
    public class MockOfficeRepository : IOfficeRepository
    {
        private readonly List<OfficeEntity> _offices = new List<OfficeEntity>();

        public async Task<IEnumerable<OfficeEntity>> GetAllAsync(string? address, string? phoneNumber, StandartStatus? isActive, CancellationToken cancellationToken)
        {
            return await Task.Run(() =>
            {
                var query = _offices.AsEnumerable();

                if (!string.IsNullOrWhiteSpace(address))
                {
                    query = query.Where(x => x.Address.Contains(address, StringComparison.OrdinalIgnoreCase));
                }

                if (!string.IsNullOrWhiteSpace(phoneNumber))
                {
                    query = query.Where(x => x.RegistryPhoneNumber.Contains(phoneNumber));
                }

                if (isActive.HasValue)
                {
                    query = query.Where(x => x.IsActive == isActive.Value);
                }

                return query.AsEnumerable();
            }, cancellationToken);
        }

        public async Task<OfficeEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await Task.Run(() => _offices.Find(x => x.Id == id), cancellationToken);
        }

        public async Task<IEnumerable<OfficeEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await Task.Run(() => _offices.AsEnumerable(), cancellationToken);
        }

        public async Task<OfficeEntity> AddAsync(OfficeEntity entity, CancellationToken cancellationToken)
        {
            return await Task.Run(() =>
            {
                _offices.Add(entity);
                return entity;
            }, cancellationToken);
        }

        public async Task<OfficeEntity> UpdateAsync(OfficeEntity entity, CancellationToken cancellationToken)
        {
            return await Task.Run(() =>
            {
                var index = _offices.FindIndex(x => x.Id == entity.Id);
                if (index != -1)
                {
                    _offices[index] = entity;
                }
                return entity;
            }, cancellationToken);
        }

        public async Task DeleteAsync(OfficeEntity entity, CancellationToken cancellationToken)
        {
            await Task.Run(() => _offices.Remove(entity), cancellationToken);
        }
    }
}
