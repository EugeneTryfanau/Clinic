namespace Documents.BLL.Models
{
    public class BlobDto
    {
        public string? Uri { get; set; }
        public string? Name { get; set; }
        public string? TypeContent { get; set; }
        public Stream? Content { get; set; }
    }
}
