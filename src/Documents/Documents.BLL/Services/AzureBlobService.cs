using Azure.Storage.Blobs;
using Documents.BLL.Interfaces;
using Documents.BLL.Models;
using Microsoft.AspNetCore.Http;

namespace Documents.BLL.Services
{
    public class AzureBlobService
    {
        private readonly IPdfGeneratorService _pdfGeneratorService;

        private const string DocumentContainerName = "appointmentresults";
        private const string PictureContainerName = "photos";

        private readonly BlobContainerClient _documentContainerClient;
        private readonly BlobContainerClient _photoContainerClient;

        public AzureBlobService(BlobServiceClient blobServiceClient, IPdfGeneratorService pdfGeneratorService)
        {
            _pdfGeneratorService = pdfGeneratorService;

            _documentContainerClient = blobServiceClient.GetBlobContainerClient(DocumentContainerName);
            _documentContainerClient.CreateIfNotExists();

            _photoContainerClient = blobServiceClient.GetBlobContainerClient(PictureContainerName);
            _photoContainerClient.CreateIfNotExists();
        }

        public async Task<string> UplaodBlobFile(string fileName, string jsonResult, /*Stream pictureStream*/ IFormFile? formFile)
        {
            if (formFile is not null)
            {
                var blobClient = _photoContainerClient.GetBlobClient(fileName);
                await blobClient.UploadAsync(formFile.OpenReadStream());

                return blobClient.Uri.AbsoluteUri + blobClient.Name;
            }
            else
            {
                var blobClient = _documentContainerClient.GetBlobClient(fileName);
                await blobClient.UploadAsync(await CreatePdfDocumentStream(jsonResult), true);

                return blobClient.Uri.AbsoluteUri + blobClient.Name;
            }
        }

        public async Task<BlobDto?> DownloadBlobFile(string fileName, bool isPhoto)
        {
            if (isPhoto)
                return await DownloadProcess(fileName, _photoContainerClient);
            else
                return await DownloadProcess(fileName, _documentContainerClient);
        }

        public async Task DeleteBlobFile(string fileName, bool isPhoto)
        {
            if (isPhoto)
                await DeleteProcess(fileName, _photoContainerClient);
            else
                await DeleteProcess(fileName, _documentContainerClient);
        }

        private static async Task<BlobDto?> DownloadProcess(string fileName, BlobContainerClient client)
        {
            var file = client.GetBlobClient(fileName);

            if (await file.ExistsAsync())
            {
                var data = await file.OpenReadAsync();
                Stream blobContent = data;

                var content = await file.DownloadContentAsync();

                string name = fileName;
                string contentType = content.Value.Details.ContentType;

                return new BlobDto { Content = blobContent, Name = name, TypeContent = contentType };
            }

            return null;
        }

        private static async Task DeleteProcess(string fileName, BlobContainerClient client)
        {
            var file = client.GetBlobClient(fileName);
            await file.DeleteAsync();
        }

        private async Task<Stream> CreatePdfDocumentStream(string json)
        {
            return await _pdfGeneratorService.GeneratePDFAsync(json);
        }
    }
}
