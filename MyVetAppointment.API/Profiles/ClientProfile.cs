using AutoMapper;
using MyVetAppointment.Domain.Entities;
using MyVetAppointment.API.DTOs;

namespace MyVetAppointment.API.Profiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<Client, CreateClientDto>().ReverseMap();
        }
    }
}
