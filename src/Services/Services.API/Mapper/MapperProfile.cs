using AutoMapper;
using Services.API.ViewModels.Service;
using Services.API.ViewModels.ServiceCategory;
using Services.BLL.Models;
using Services.DAL.Entities;

namespace Services.API.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ServiceViewModel, Service>().ReverseMap();
            CreateMap<CreateServiceViewModel, Service>().ReverseMap();
            CreateMap<UpdateServiceViewModel, Service>().ReverseMap();

            CreateMap<ServiceCategoryViewModel, ServiceCategory>().ReverseMap();
            CreateMap<CreateServiceCategoryViewModel, ServiceCategory>().ReverseMap();
            CreateMap<UpdateServiceCategoryViewModel, ServiceCategory>().ReverseMap();

            CreateMap<ServiceEntity, Service>().ReverseMap();
            CreateMap<ServiceCategoryEntity, ServiceCategory>().ReverseMap();
        }
    }
}
