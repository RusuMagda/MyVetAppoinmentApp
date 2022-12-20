using FluentValidation;
using MyVetAppointment.API.DTOs;
using MyVetAppointment.Domain.Entities;

namespace MyVetAppointment.API.Validators
{
    public class AppointmentValidator : AbstractValidator<CreateAppointmentDto>
    {
        public AppointmentValidator()
        {
            RuleFor(appointment => appointment.StartTime).NotEmpty().Must(BeFuture);
            RuleFor(appointment => appointment.EndTime).NotEmpty().Must(BeFuture);
            RuleFor(appointment => appointment.Description).NotEmpty();
        }
        protected bool BeFuture(DateTime date)
        {
            if (date < DateTime.Now)
                return false;
            return true;
        }
    }
}