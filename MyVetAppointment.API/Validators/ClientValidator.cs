using FluentValidation;
using MyVetAppointment.API.DTOs;
using MyVetAppointment.Domain.Entities;
using System.Text.RegularExpressions;

namespace MyVetAppointment.API.Validators
{
    public class ClientValidator : AbstractValidator<CreateClientDto>
    {
        public ClientValidator()
        {
            RuleFor(client => client.Name).NotEmpty();
            RuleFor(client => client.EMail).NotEmpty().EmailAddress();
            RuleFor(client => client.PhoneNumber).NotEmpty().MaximumLength(10).Must(IsPhoneValid);
        }
        public static bool IsPhoneValid(string phoneNumber)
        {
            string regex = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";
                return Regex.IsMatch(phoneNumber, regex);
        }
    }
}