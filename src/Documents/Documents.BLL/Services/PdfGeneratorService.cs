using Documents.BLL.Interfaces;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using RazorLight;
using System.Reflection;
using Documents.BLL.Templates;

namespace Documents.BLL.Services
{
    public class PdfGeneratorService : IPdfGeneratorService
    {
        public async Task<Stream> GeneratePDFAsync(string fileContent)
        {
            var stream = new MemoryStream();
            var writer = new PdfWriter(stream);
            var pdf = new PdfDocument(writer);
            var document = new Document(pdf);

            document.Add(new Paragraph(await GetFilledPdfTemplate(fileContent)));
            document.Close();

            return stream;
        }

        private static async Task<string> GetFilledPdfTemplate(string data)
        {
            string template = PdfTemplates.ResultPdfTemplate;

            RazorLightEngine engine = new RazorLightEngineBuilder()
                .UseEmbeddedResourcesProject(Assembly.GetEntryAssembly())
                .Build();

            string result = await engine.CompileRenderStringAsync("cacheKey", template, data);

            return result;
        }
    }
}
