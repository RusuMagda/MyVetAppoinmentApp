using FluentValidation;
using MyVetAppointment.Domain.Entities;

namespace MyVetAppointment.API.Validators
{
    public class DrugValidator : AbstractValidator<Drug>
    {
        public DrugValidator()
        {
            RuleFor(drug => drug.DrugName).NotNull();
            RuleFor(drug => drug.Stock).GreaterThan(0);
            RuleFor(drug => drug.Price).GreaterThan(0);
            RuleFor(drug => drug.Quantity).GreaterThan(0);
        }
    }
}