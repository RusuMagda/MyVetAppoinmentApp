using FluentValidation;

namespace MyVetAppointment.Application.Commands
{
    public class CreatePetCommandValidator : AbstractValidator<CreatePetCommand>
    {
        public CreatePetCommandValidator()
        {
            RuleFor(p => p.Name).NotEmpty().NotNull();
            RuleFor(p => p.OwnerId).NotEmpty().NotNull();
            RuleFor(p => p.Birthdate).NotEmpty().NotNull().Must(BeOver1Day);
        }

        protected static bool BeOver1Day(DateTime date)
        {
            return date <= DateTime.Now;
        }
    }
}
