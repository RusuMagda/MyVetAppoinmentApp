using FluentValidation;
using MyVetAppoinment.Domain.Entities;

namespace MyVetAppointment.API.Validators
{
    public class ClientValidator : AbstractValidator<Client>
    {
        public ClientValidator()
        {
            RuleFor(client => client.Name).NotNull();
            RuleFor(client => client.EMail).NotNull().EmailAddress();
            RuleFor(client => client.PhoneNumber).NotNull().MaximumLength(50);
        }
    }
}

