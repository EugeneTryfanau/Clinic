using Clinic.BLL.Models;
using Clinic.DAL.Entities;

namespace Clinic.IntegrationTests.TestData.Offices
{
    public class TestOfficeModels
    {
        public static Office CreateOfficeRequest => new()
        {
            Id = new Guid("b37b1e25-8a6f-48dd-965b-0581911bb383"),
            Address = "Lenina",
            RegistryPhoneNumber = "375296666666",
            IsActive = OfficeStatus.Active
        };

        public static Office UpdateOfficeModel => new()
        {
            Id = new Guid("b37b1e25-8a6f-48dd-965b-0581911bb383"),
            Address = "Terehina",
            RegistryPhoneNumber = "375295555555",
            IsActive = OfficeStatus.Active
        };
    }
}
