using AutoMapper;
using Documents.API.ViewModels;
using Documents.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace Documents.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController(AzureBlobService azureBlobService, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<BlobViewModel> Download(string fileName, bool isPhoto)
        {
            return mapper.Map<BlobViewModel>(await azureBlobService.DownloadBlobFile(fileName, isPhoto));
        }

        [HttpPost]
        public async Task<string> Upload(string fileName, string jsonResult, Stream pictureStream)
        {
            return await azureBlobService.UplaodBlobFile(fileName, jsonResult, pictureStream);
        }

        [HttpDelete]
        public async Task Delete(string fileName, bool isPhoto)
        {
            await azureBlobService.DeleteBlobFile(fileName, isPhoto);
        }
    }
}
