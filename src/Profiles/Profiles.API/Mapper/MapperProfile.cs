using AutoMapper;
using Profiles.BLL.Models;
using Profiles.DAL.Entities;

namespace Profiles.API.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AccountEntity, Account>().ReverseMap();
            CreateMap<DoctorEntity, Doctor>().ReverseMap();
            CreateMap<PatientEntity, Patient>().ReverseMap();
            CreateMap<ReceptionistEntity, Receptionist>().ReverseMap();
            CreateMap<SpecializationEntity, Specialization>().ReverseMap();
        }
    }
}
