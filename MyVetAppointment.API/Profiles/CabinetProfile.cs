using AutoMapper;
using MyVetAppoinment.Domain.Entities;
using MyVetAppointment.API.DTOs;

namespace MyVetAppointment.API.Profiles
{
    public class CabinetProfile : Profile
    {
        public CabinetProfile()
        {
            CreateMap<Cabinet, CreateCabinetDto>().ReverseMap();
        }
    }
}
