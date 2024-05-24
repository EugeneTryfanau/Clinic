using Clinic.BLL.Models;
using StandartCRUD;

namespace Clinic.BLL.Interfaces
{
    public interface ICacheOfficeService
    {
        Task<IEnumerable<Office>> TryGetOrCreateAsync(string? address, string? phoneNumber, StandartStatus? isActive, CancellationToken cancellationToken);
    }
}
