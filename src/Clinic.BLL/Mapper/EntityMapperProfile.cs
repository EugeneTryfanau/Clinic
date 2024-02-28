using AutoMapper;
using Clinic.BLL.Models;
using Clinic.DAL.Entities;

namespace Clinic.BLL.Mapper
{
    public class EntityMapperProfile : Profile
    {
        public EntityMapperProfile()
        {
            CreateMap<OfficeEntity, Office>().ReverseMap();
        }
    }
}
