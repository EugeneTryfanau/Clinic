using Clinic.DAL.Entities;
using static Clinic.DAL.Entities.EnumsEntity;

namespace Clinic.DAL.Interfaces
{
    public interface IOfficeRepository : IRepository<OfficeEntity>
    {
        Task<IEnumerable<OfficeEntity>> GetAllAsync(string? address, string? phoneNumber, OfficeStatus? isActive, CancellationToken cancellationToken);
    }
}
