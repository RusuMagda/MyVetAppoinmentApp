using MediatR;
using MyVetAppointment.Application.Response;

namespace MyVetAppointment.Application.Commands
{
    public class DeleteAppointmentByIdCommand : IRequest<AppointmentResponse>
    {
        public Guid Id { get; set; }
    }
}
