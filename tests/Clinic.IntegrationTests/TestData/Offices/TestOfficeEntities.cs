using Clinic.DAL.Entities;

namespace Clinic.IntegrationTests.TestData.Offices
{
    public static class TestOfficeEntities
    {
        public static OfficeEntity Office => new()
        {
            Id = new Guid("b37b1e25-8a6f-48dd-965b-0581911bb383"),
            Address = "Terehina",
            RegistryPhoneNumber = "375293849405",
            IsActive = OfficeStatus.Active
        };

        public static OfficeEntity UpdatedOffice => new()
        {
            Id = new Guid("b37b1e25-8a6f-48dd-965b-0581911bb383"),
            Address = "Terehina",
            RegistryPhoneNumber = "375296475784",
            IsActive = OfficeStatus.Active
        };

        public static List<OfficeEntity> OfficeEntityCollection => new()
        {
            Office,
        };
    }
}
