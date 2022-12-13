using FluentValidation;
using MyVetAppoinment.Domain.Entities;

namespace MyVetAppointment.API.Validators
{
    public class CabinetValidator : AbstractValidator<Cabinet>
    {
        public CabinetValidator()
        {
            RuleFor(cabinet => cabinet.Address).Length(5, 250);
        }
    }
}

