namespace Appointments.API.ViewModels.Document
{
    public class DocumentViewModel
    {
        public Guid Id { get; set; }
        public string? Url { get; set; } = string.Empty;

        public Guid? ResultId { get; set; } = Guid.Empty;
    }
}
