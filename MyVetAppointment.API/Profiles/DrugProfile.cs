using AutoMapper;
using MyVetAppointment.Domain.Entities;
using MyVetAppointment.API.DTOs;

namespace MyVetAppointment.API.Profiles
{
    public class DrugProfile : Profile
    {
        public DrugProfile()
        {
            CreateMap<Drug, CreateDrugDto>().ReverseMap();
        }
    }
}
