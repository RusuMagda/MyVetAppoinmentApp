using MediatR;
using MyVetAppointment.Application.Response;

namespace MyVetAppointment.Application.Queries
{
    public class GetAllAppointmentsQuery : IRequest<List<AppointmentResponse>>
    {
    }
}
