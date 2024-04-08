using Clinic.API.ViewModels.Office;
using Clinic.BLL.Models;
using StandartCRUD;

namespace Clinic.IntegrationTests.TestData.Offices;

public static class TestOfficeViewModels
{
    public static OfficeViewModel Office => new()
    {
        Id = new Guid("b37b1e25-8a6f-48dd-965b-0581911bb383"),
        Address = "Lenina",
        RegistryPhoneNumber = "375296666666",
        IsActive = StandartStatus.Active
    };

    public static Office UpdateOfficeModel => new()
    {
        Id = new Guid("b37b1e25-8a6f-48dd-965b-0581911bb383"),
        Address = "Terehina",
        RegistryPhoneNumber = "375295555555",
        IsActive = StandartStatus.Active
    };

    public static OfficeViewModel CreateOffice(Guid? id = null) => new()
    {
        Id = id is null ? Guid.NewGuid() : id.Value,
        Address = "Lenina",
        RegistryPhoneNumber = "375296666666",
        IsActive = StandartStatus.Active
    };
}
