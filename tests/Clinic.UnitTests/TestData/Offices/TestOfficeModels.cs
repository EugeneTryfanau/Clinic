using Clinic.BLL.Models;
using Clinic.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clinic.UnitTests.TestData.Offices
{
    public static class TestOfficeModels
    {
        public static OfficeEntity Office => new()
        {
            Id = Guid.NewGuid(),
            Address = "Lenina",
            RegistryPhoneNumber = "375296666666",
            IsActive = StandartStatus.Active
        };

        public static OfficeEntity UpdateOffice => new()
        {
            Id = Office.Id,
            Address = "Terehina",
            RegistryPhoneNumber = "375295555555",
            IsActive = StandartStatus.Active
        };

        public static List<Office> Offices => new()
        {
            CreateOffice(null, StandartStatus.Active), CreateOffice(null, StandartStatus.None), CreateOffice(null, StandartStatus.Inactive)
        };

        public static Office CreateOffice(Guid? id = null, StandartStatus status = StandartStatus.Active) => new()
        {
            Id = id is null ? Guid.NewGuid() : id.Value,
            Address = "Lenina",
            RegistryPhoneNumber = "375296666666",
            IsActive = status 
        };

        public static List<Office> SortOffices(string? address, string? phoneNumber, StandartStatus? isActive, CancellationToken token)
        {
            var sortedOffices = Offices;

            if (!string.IsNullOrWhiteSpace(address))
            {
                var addressLower = address.ToLower();
                sortedOffices = sortedOffices.Where(x => EF.Functions.Like(x.Address.ToLower(), $"%{addressLower}%")).ToList();
            }

            if (!string.IsNullOrWhiteSpace(phoneNumber))
            {
                sortedOffices = sortedOffices.Where(x => EF.Functions.Like(x.RegistryPhoneNumber, $"%{phoneNumber}%")).ToList();
            }

            if (isActive != null)
            {
                sortedOffices = sortedOffices.Where(x => x.IsActive == isActive).ToList();
            }

            return sortedOffices;
        }
    }
}
