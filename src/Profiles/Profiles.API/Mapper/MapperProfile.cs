using AutoMapper;
using Profiles.API.ViewModels.Account;
using Profiles.API.ViewModels.Doctor;
using Profiles.API.ViewModels.Patient;
using Profiles.API.ViewModels.Receptionist;
using Profiles.API.ViewModels.Specialization;
using Profiles.BLL.Models;
using Profiles.DAL.Entities;

namespace Profiles.API.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AccountViewModel, Account>().ReverseMap();
            CreateMap<CreateAccountViewModel, Account>().ReverseMap();
            CreateMap<UpdateAccountViewModel, Account>().ReverseMap();

            CreateMap<DoctorViewModel, Doctor>().ReverseMap();
            CreateMap<CreateDoctorViewModel, Doctor>().ReverseMap();
            CreateMap<UpdateDoctorViewModel, Doctor>().ReverseMap();

            CreateMap<PatientViewModel, Patient>().ReverseMap();
            CreateMap<CreatePatientViewModel, Patient>().ReverseMap();
            CreateMap<UpdatePatientViewModel, Patient>().ReverseMap();

            CreateMap<ReceptionistViewModel, Receptionist>().ReverseMap();
            CreateMap<CreateReceptionistViewModel, Receptionist>().ReverseMap();
            CreateMap<UpdateReceptionistViewModel, Receptionist>().ReverseMap();

            CreateMap<SpecializationViewModel, Specialization>().ReverseMap();
            CreateMap<CreateSpecializationViewModel, Specialization>().ReverseMap();
            CreateMap<UpdateSpecializationViewModel, Specialization>().ReverseMap();

            CreateMap<AccountEntity, Account>().ReverseMap();
            CreateMap<DoctorEntity, Doctor>().ReverseMap();
            CreateMap<PatientEntity, Patient>().ReverseMap();
            CreateMap<ReceptionistEntity, Receptionist>().ReverseMap();
            CreateMap<SpecializationEntity, Specialization>().ReverseMap();
        }
    }
}
