using FluentValidation;
using MyVetAppoinment.Domain.Entities;

namespace MyVetAppointment.API.Validators
{
    public class AppointmentValidator : AbstractValidator<Appointment>
    {
        public AppointmentValidator()
        {
            RuleFor(appointment => appointment.PetId).NotNull();
            RuleFor(appointment => appointment.StartTime).NotNull().Must(BeFuture);
            RuleFor(appointment => appointment.EndTime).NotNull().Must(BeFuture);
            RuleFor(appointment => appointment.CabinetId).NotNull();
        }
        protected bool BeFuture(DateTime date)
        {
            if (date < DateTime.Now)
                return false;
            return true;
        }
    }
}