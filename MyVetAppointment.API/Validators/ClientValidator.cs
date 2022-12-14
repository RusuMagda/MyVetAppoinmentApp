using FluentValidation;
using MyVetAppoinment.Domain.Entities;
using System.Text.RegularExpressions;

namespace MyVetAppointment.API.Validators
{
    public class ClientValidator : AbstractValidator<Client>
    {
        public ClientValidator()
        {
            RuleFor(client => client.Name).NotNull();
            RuleFor(client => client.EMail).NotNull().EmailAddress();
            RuleFor(client => client.PhoneNumber).NotNull().MaximumLength(10).Must(IsPhoneValid);
        }
        public static bool IsPhoneValid(string phoneNumber)
        {
            string regex = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";
                return Regex.IsMatch(phoneNumber, regex);
        }
    }
}