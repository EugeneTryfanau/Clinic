using Clinic.DAL.Entities;

namespace Clinic.DAL.Interfaces
{
    public interface IOfficeRepository : IRepository<OfficeEntity>
    {
        Task<IEnumerable<OfficeEntity>> GetAllAsync(string? address, string? phoneNumber, StandartStatus? isActive, CancellationToken cancellationToken);
    }
}
