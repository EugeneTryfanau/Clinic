using AutoMapper;
using Clinic.API.ViewModels.Office;
using Clinic.BLL.Models;

namespace Clinic.API.Mapper
{
    public class ViewModelMapperProfile : Profile
    {
        public ViewModelMapperProfile()
        {
            CreateMap<OfficeViewModel, Office>().ReverseMap();
            CreateMap<CreateOfficeViewModel, Office>().ReverseMap();
            CreateMap<UpdateOfficeViewModel, Office>().ReverseMap();
        }
    }
}
