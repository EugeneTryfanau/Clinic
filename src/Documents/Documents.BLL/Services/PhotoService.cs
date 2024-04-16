using AutoMapper;
using Documents.BLL.Interfaces;
using Documents.BLL.Models;
using Documents.DAL.Entities;
using Documents.DAL.Interfaces;
using StandartCRUD.StandartBLL;

namespace Documents.BLL.Services
{
    internal class PhotoService(IPhotoRepository photoRepository, IMapper mapper) :
        GenericService<PhotoEntity, Photo>(photoRepository, mapper),
        IPhotoService
    {
    }
}
