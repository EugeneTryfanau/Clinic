namespace Appointments.API.ViewModels.Document
{
    public class BaseDocumentViewModel
    {
        public string? Url { get; set; } = string.Empty;

        public Guid? ResultId { get; set; } = Guid.Empty;
    }
}
