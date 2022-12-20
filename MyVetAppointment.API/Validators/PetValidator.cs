using FluentValidation;
using MyVetAppointment.API.DTOs;
using MyVetAppointment.Domain.Entities;

namespace MyVetAppointment.API.Validators
{
    public class PetValidator : AbstractValidator<CreatePetDto>
    {
        public PetValidator()
        {
            RuleFor(pet => pet.Name).NotEmpty();
            RuleFor(pet => pet.OwnerId).NotEmpty();
            RuleFor(pet => pet.Birthdate).NotEmpty().Must(BeOver1Day);
        }
        protected bool BeOver1Day(DateTime date)
        {
            if (date > DateTime.Now)
                return false;
            return true;
        }
    }
}