using AutoMapper;
using Documents.API.ViewModels;
using Documents.BLL.Models;

namespace Documents.API.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<BlobViewModel, BlobDto>().ReverseMap();
        }
    }
}
