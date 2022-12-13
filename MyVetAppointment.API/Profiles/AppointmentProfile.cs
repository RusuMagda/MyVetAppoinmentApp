using AutoMapper;
using MyVetAppoinment.Domain.Entities;
using MyVetAppointment.API.DTOs;

namespace MyVetAppointment.API.Profiles
{
    public class AppointmentProfile : Profile
    {
        public AppointmentProfile()
        {
            CreateMap<Appointment, CreateAppointmentDto>().ReverseMap();
        }
    }
}
