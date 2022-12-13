using FluentValidation;
using MyVetAppoinment.Domain.Entities;

namespace MyVetAppointment.API.Validators
{
    public class ShopValidator : AbstractValidator<Shop>
    {
        public ShopValidator()
        {
            RuleFor(shop => shop.ShopName).NotNull();
            RuleFor(shop => shop.CabinetId).NotNull();
            RuleForEach(x => x.Drugs).SetValidator(new DrugValidator());

        }
    }
}

