namespace Clinic.DAL.Entities
{
    public class ResultEntity : Entity
    {
        public required string Complaints { get; set; }
        public required string Conclusion { get; set; }
        public string? Recomendations { get; set; }

        public Guid AppointmentId { get; set; }

        public virtual AppointmentEntity? Appointment { get; set; }
    }
}
