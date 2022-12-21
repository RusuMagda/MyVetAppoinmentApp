using MediatR;
using MyVetAppointment.Application.Response;

namespace MyVetAppointment.Application.Queries
{
    public class GetAppointmentByIdQuery : IRequest<AppointmentResponse>
    {
        public Guid Id { get; set; }
    }
}
