using Clinic.DAL.Entities;

namespace Clinic.IntegrationTests.TestData.Offices
{
    public static class TestOfficeEntities
    {
        public static OfficeEntity Office => new()
        {
            Address = "Terehina",
            RegistryPhoneNumber = "375293849405",
            IsActive = EnumsEntity.OfficeStatus.Active
        };

        public static OfficeEntity UpdatedOffice => new()
        {
            Address = "Terehina 9",
            RegistryPhoneNumber = "375296475784",
            IsActive = EnumsEntity.OfficeStatus.Inactive
        };

        public static List<OfficeEntity> OfficeEntityCollection => new()
        {
            Office,
        };
    }
}
