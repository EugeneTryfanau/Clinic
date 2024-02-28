using Clinic.BLL.Models;
using Clinic.DAL.Entities;
using static Clinic.DAL.Entities.EnumsEntity;

namespace Clinic.BLL.Interfaces
{
    public interface IOfficeService : IGenericService<OfficeEntity, Office>
    {
        Task<IEnumerable<Office>> GetAllAsync(string? address, string? phoneNumber, OfficeStatus? isActive, CancellationToken cancellationToken);
    }
}
