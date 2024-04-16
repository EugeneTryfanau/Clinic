using AutoMapper;
using Documents.BLL.Models;
using Documents.DAL.Entities;

namespace Documents.API.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {

            CreateMap<DocumentEntity, Document>().ReverseMap();
            CreateMap<PhotoEntity, Photo>().ReverseMap();
        }
    }
}
