using FluentValidation;
using MyVetAppointment.API.DTOs;
using MyVetAppointment.Domain.Entities;

namespace MyVetAppointment.API.Validators
{
    public class DrugValidator : AbstractValidator<CreateDrugDto>
    {
        public DrugValidator()
        {
            RuleFor(drug => drug.DrugName).NotEmpty();
            RuleFor(drug => drug.DrugDescription).NotEmpty();
            RuleFor(drug => drug.Stock).GreaterThan(0);
            RuleFor(drug => drug.Price).GreaterThan(0);
            RuleFor(drug => drug.SaleForm).NotEmpty();
            RuleFor(drug => drug.Quantity).GreaterThan(0);
            RuleFor(drug => drug.QuantityMeasure).NotEmpty();
        }
    }
}