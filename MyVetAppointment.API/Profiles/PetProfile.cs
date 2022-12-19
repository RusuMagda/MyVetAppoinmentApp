using AutoMapper;
using MyVetAppointment.Domain.Entities;
using MyVetAppointment.API.DTOs;

namespace MyVetAppointment.API.Profiles
{
    public class PetProfile : Profile
    {
        public PetProfile()
        {
            CreateMap<Pet, CreatePetDto>().ReverseMap();
        }
    }
}
