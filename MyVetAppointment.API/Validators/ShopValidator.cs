using FluentValidation;
using MyVetAppointment.API.DTOs;
using MyVetAppointment.Domain.Entities;

namespace MyVetAppointment.API.Validators
{
    public class ShopValidator : AbstractValidator<CreateShopDto>
    {
        public ShopValidator()
        {
            RuleFor(shop => shop.ShopName).NotEmpty();
            RuleFor(shop => shop.CabinetId).NotEmpty();

        }
    }
}