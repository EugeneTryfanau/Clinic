namespace Clinic.DAL.Entities
{
    public class SpecializationEntity : Entity
    {
        public required string SpecializationName { get; set; }
        public StandartStatus IsActive { get; set; }
    }
}
