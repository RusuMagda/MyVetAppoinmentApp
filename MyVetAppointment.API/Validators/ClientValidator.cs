using FluentValidation;
using MyVetAppointment.API.DTOs;
using MyVetAppointment.Domain.Entities;
using MyVetAppointment.Infrastructure.Data;
using MyVetAppointment.Infrastructure.Repositories;
using System;
using System.Text.RegularExpressions;

namespace MyVetAppointment.API.Validators
{
    public class ClientValidator : AbstractValidator<CreateClientDto>
    {
        private IClientRepository clientRepository;
        public ClientValidator(IClientRepository repository)
        {

            this.clientRepository = repository;
           
            RuleFor(client => client.Name).NotNull();
            RuleFor(client => client.EMail).NotNull().EmailAddress().Must(BeUniqueAsync).WithMessage("Email already exists");

            RuleFor(client => client.PhoneNumber).NotNull().MaximumLength(10).Must(IsPhoneValid);

        }
        public static bool IsPhoneValid(string phoneNumber)
        {
            string regex = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";
                return Regex.IsMatch(phoneNumber, regex);
        }
        private bool BeUniqueAsync(string email)
        {
            if (( clientRepository.GetByEmail(email)) == null)
                return true;
            return false;
        }
    }

    
}