using MediatR;
using MyVetAppointment.Application.Response;
using MyVetAppointment.Domain.Entities;

namespace MyVetAppointment.Application.Queries
{
    public class GetPetAppointmentsQuery : IRequest<List<AppointmentResponse>>
    {
        public Guid Id { get; set; }
    }
}
