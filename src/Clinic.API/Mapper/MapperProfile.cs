using AutoMapper;
using Clinic.API.ViewModels.Office;
using Clinic.BLL.Models;
using Clinic.DAL.Entities;

namespace Clinic.API.Mapper
{
    public partial class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<OfficeViewModel, Office>().ReverseMap();
            CreateMap<CreateOfficeViewModel, Office>().ReverseMap();
            CreateMap<UpdateOfficeViewModel, Office>().ReverseMap();

            CreateMap<OfficeEntity, Office>().ReverseMap();
        }
    }
}
