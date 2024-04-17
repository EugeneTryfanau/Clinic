using Documents.BLL.Interfaces;
using Documents.BLL.Templates;
using iText.Html2pdf;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using RazorLight;
using System.Reflection;

namespace Documents.BLL.Services
{
    public class PdfGeneratorService : IPdfGeneratorService
    {
        public async Task<Stream> GeneratePDFAsync(string fileContent)
        {
            PageSize pageSize = new PageSize(612, 792);

            MemoryStream masterStream = new MemoryStream();

            AppendHTML(masterStream, await GetFilledPdfTemplate(fileContent), pageSize);
            masterStream.Position = 0;

            return masterStream;
        }

        private static void AppendHTML(MemoryStream masterStream, string html, PageSize pageSize)
        {
            using MemoryStream componentStream = new MemoryStream();
            using (MemoryStream tempStream = new MemoryStream())
            {
                using PdfWriter pdfWriter = new PdfWriter(tempStream);
                pdfWriter.SetCloseStream(false);

                using PdfDocument document = new PdfDocument(pdfWriter);
                document.SetDefaultPageSize(pageSize);

                HtmlConverter.ConvertToPdf(html, document, new ConverterProperties());

                tempStream.WriteTo(componentStream);
            }

            if (masterStream.Length == 0)
                componentStream.WriteTo(masterStream);
            else
            {
                using MemoryStream tempStream = new MemoryStream();
                masterStream.Position = 0;
                componentStream.Position = 0;

                using (PdfDocument combinedDocument = new PdfDocument(new PdfReader(masterStream), new PdfWriter(tempStream)))
                {
                    using (PdfDocument componentDocument = new PdfDocument(new PdfReader(componentStream)))
                    {
                        combinedDocument.SetCloseWriter(false);

                        componentDocument.CopyPagesTo(1, componentDocument.GetNumberOfPages(), combinedDocument);
                    }

                    combinedDocument.Close();
                }

                byte[] temporaryBytes = tempStream.ToArray();
                masterStream.Position = 0;
                masterStream.SetLength(temporaryBytes.Length);
                masterStream.Capacity = temporaryBytes.Length;
                masterStream.Write(temporaryBytes, 0, temporaryBytes.Length);
            }
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
