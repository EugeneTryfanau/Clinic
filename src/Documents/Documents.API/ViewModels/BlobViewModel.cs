namespace Documents.API.ViewModels
{
    public class BlobViewModel
    {
        public string? Uri { get; set; }
        public string? Name { get; set; }
        public string? TypeContent { get; set; }
        public Stream? Content { get; set; }
    }
}
