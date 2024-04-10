using AutoMapper;
using Clinic.API.ViewModels.Office;
using Clinic.BLL.Models;
using Clinic.DAL.Entities;

namespace Clinic.API.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<OfficeViewModel, Office>().ReverseMap();

            CreateMap<OfficeEntity, Office>().ReverseMap();
        }
    }
}
