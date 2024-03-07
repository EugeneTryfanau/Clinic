namespace Clinic.DAL.Entities
{
    public enum StandartStatus
    {
        None = 0,
        Active,
        Inactive
    }

    public enum DoctorStatus
    {
        None = 0,
        AtWork,
        OnVacation,
        SickDay,
        SickLeave,
        SelfIsolation,
        LeaveWithoutPay,
        Inactive
    }
}
