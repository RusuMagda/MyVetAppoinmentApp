using FluentValidation;
using MyVetAppointment.API.DTOs;
using MyVetAppointment.Domain.Entities;
using System.Text.RegularExpressions;

namespace MyVetAppointment.API.Validators
{
    public class CabinetValidator : AbstractValidator<CreateCabinetDto>
    {
        public CabinetValidator()
        {
            RuleFor(client => client.Name).NotEmpty();
            RuleFor(cabinet => cabinet.Address).Length(5, 250);
            RuleFor(cabinet => cabinet.PhoneNumber).Must(IsPhoneValid);
            RuleFor(cabinet => cabinet.Description).NotEmpty();

        }
        public static bool IsPhoneValid(string phoneNumber)
        {
            string regex = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";
            return Regex.IsMatch(phoneNumber, regex);
        }
    }
}