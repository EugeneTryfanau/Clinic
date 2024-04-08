using StandartCRUD;

namespace Appointments.API.ViewModels
{
    public record AppointmentSearchRequestData(Guid? PatientId, Guid? DoctorId, Guid? ServiceId, bool? IsApproved, Guid? AppountmentId, Guid? ResultId);
}
