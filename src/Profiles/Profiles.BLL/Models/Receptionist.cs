namespace Profiles.BLL.Models
{
    public class Receptionist : BaseModel
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? MiddleName { get; set; }

        public Guid? AccountId { get; set; }
        public Guid? OfficeId { get; set; }
    }
}
