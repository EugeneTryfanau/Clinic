using Appointments.API.ViewModels.Appointment;
using Appointments.API.ViewModels.Document;
using Appointments.API.ViewModels.Result;
using Appointments.BLL.Models;
using Appointments.DAL.Entities;
using AutoMapper;

namespace Appointments.API.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AppointmentViewModel, Appointment>().ReverseMap();

            CreateMap<ResultViewModel, Result>().ReverseMap();

            CreateMap<DocumentViewModel, Document>().ReverseMap();

            CreateMap<AppointmentEntity, Appointment>().ReverseMap();
            CreateMap<ResultEntity, Result>().ReverseMap();
            CreateMap<DocumentEntity, Document>().ReverseMap();
        }
    }
}
