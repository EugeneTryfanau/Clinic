using Clinic.BLL.Models;
using Clinic.DAL.Entities;

namespace Clinic.BLL.Interfaces
{
    public interface IOfficeService : IGenericService<OfficeEntity, Office>
    {
        Task<IEnumerable<Office>> GetAllAsync(string address, string phoneNumber, string isActive, CancellationToken cancellationToken);

    }
}
