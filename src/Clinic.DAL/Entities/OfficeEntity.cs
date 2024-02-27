namespace Clinic.DAL.Entities
{
    public class OfficeEntity
    {
        public Guid Id { get; set; }
        public required string Address { get; set; }
        public required string RegistryPhoneNumber { get; set; }
        public bool IsActive { get; set; }
    }
}
