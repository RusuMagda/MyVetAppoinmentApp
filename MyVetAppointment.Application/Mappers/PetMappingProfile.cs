using AutoMapper;
using MyVetAppointment.Application.Commands;
using MyVetAppointment.Application.Response;
using MyVetAppointment.Domain.Entities;

namespace MyVetAppointment.Application.Mappers
{
    public class PetMappingProfile : Profile
    {
        public PetMappingProfile()
        {
            CreateMap<Pet, PetResponse>().ReverseMap();
            CreateMap<Pet, CreatePetCommand>().ReverseMap();
            CreateMap<Pet, DeletePetByIdCommand>().ReverseMap();
            CreateMap<Pet, UpdatePetCommand>().ReverseMap();
        }
    }
}
