using AutoMapper;
using MyVetAppoinment.Domain.Entities;
using MyVetAppointment.API.DTOs;

namespace MyVetAppointment.API.Profiles
{
    public class ShopProfile : Profile
    {
        public ShopProfile()
        {
            CreateMap<Shop, CreateShopDto>().ReverseMap();
        }
    }
}
