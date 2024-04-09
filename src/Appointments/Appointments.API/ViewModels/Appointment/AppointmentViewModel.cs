namespace Appointments.API.ViewModels.Appointment
{
    public class AppointmentViewModel
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public bool IsApproved { get; set; }

        public Guid? PatientId { get; set; } = Guid.Empty;
        public Guid? DoctorId { get; set; } = Guid.Empty;
        public Guid? ServiceId { get; set; } = Guid.Empty;
    }
}
