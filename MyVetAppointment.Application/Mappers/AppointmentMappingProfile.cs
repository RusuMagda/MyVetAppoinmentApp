using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MyVetAppointment.Application.Commands;
using MyVetAppointment.Application.Response;
using MyVetAppointment.Domain.Entities;

namespace MyVetAppointment.Application.Mappers
{
    public class AppointmentMappingProfile : Profile
    {
        public AppointmentMappingProfile()
        {
            CreateMap<Appointment, AppointmentResponse>().ReverseMap();
            CreateMap<Appointment, CreateAppointmentCommand>().ReverseMap();
        }
    }
}
