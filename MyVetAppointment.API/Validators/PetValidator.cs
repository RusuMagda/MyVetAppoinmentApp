using FluentValidation;
using MyVetAppoinment.Domain.Entities;

namespace MyVetAppointment.API.Validators
{
    public class PetValidator : AbstractValidator<Pet>
    {
        public PetValidator()
        {
            RuleFor(pet => pet.Name).NotNull();
            RuleFor(pet => pet.OwnerId).NotNull();
            RuleFor(pet => pet.Birthdate).NotNull().Must(BeOver1Day);
            RuleForEach(x => x.Appointments).SetValidator(new AppointmentValidator());
        }
        protected bool BeOver1Day(DateTime date)
        {
            if (date > DateTime.Now)
                return false;
            return true;
        }
    }
}