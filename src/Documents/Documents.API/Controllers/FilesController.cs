using AutoMapper;
using Documents.API.ViewModels;
using Documents.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace Documents.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController(AzureBlobService azureBlobService, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Download(string fileName, bool isPhoto)
        {
            var fileData = mapper.Map<BlobViewModel>(await azureBlobService.DownloadBlobFile(fileName, isPhoto));
            return File(fileData.Content!, fileData.TypeContent!, fileData.Name);
        }

        [HttpPost]
        public async Task<string> Upload(string fileName, string jsonResult = "", IFormFile? formFile = null)
        {
            return await azureBlobService.UplaodBlobFile(fileName, jsonResult, formFile);
        }

        [HttpDelete]
        public async Task Delete(string fileName, bool isPhoto)
        {
            await azureBlobService.DeleteBlobFile(fileName, isPhoto);
        }
    }
}
