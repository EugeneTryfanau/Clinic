namespace Documents.BLL.Interfaces
{
    public interface IPdfGeneratorService
    {
        Task<Stream> GeneratePDFAsync(string fileContent);
    }
}
