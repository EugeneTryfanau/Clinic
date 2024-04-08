namespace Appointments.API.ViewModels.Result
{
    public class BaseResultViewModel
    {
        public string? Complaints { get; set; } = string.Empty;
        public string? Conclusion { get; set; } = string.Empty;
        public string? Recomendations { get; set; } = string.Empty;

        public Guid? AppointmentId { get; set; } = Guid.Empty;
    }
}
