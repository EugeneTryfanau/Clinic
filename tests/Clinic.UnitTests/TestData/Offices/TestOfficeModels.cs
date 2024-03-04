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
            IsActive = OfficeStatus.Active
        };

        public static OfficeEntity UpdateOffice => new()
        {
            Id = Office.Id,
            Address = "Terehina",
            RegistryPhoneNumber = "375295555555",
            IsActive = OfficeStatus.Active
        };

        public static List<Office> Offices => new()
        {
            CreateOffice(null, 1), CreateOffice(null, 0), CreateOffice(null, 2)
        };

        public static Office CreateOffice(Guid? id = null, int status = 1) => new()
        {
            Id = id is null ? Guid.NewGuid() : id.Value,
            Address = "Lenina",
            RegistryPhoneNumber = "375296666666",
            IsActive = status == 1 ? OfficeStatus.Active : status == 2 ? OfficeStatus.Inactive : OfficeStatus.None
        };

        public static List<Office> SortOffices(string? address, string? phoneNumber, OfficeStatus? isActive, CancellationToken token)
        {
            var sortedOffices = Offices;

            if (!string.IsNullOrWhiteSpace(address))
            {
                var firstNameLower = address.ToLower();
                sortedOffices = sortedOffices.Where(x => EF.Functions.Like(x.Address.ToLower(), $"%{address}%")).ToList();
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
