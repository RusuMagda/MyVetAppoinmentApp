using MediatR;
using MyVetAppointment.Application.Response;

namespace MyVetAppointment.Application.Queries
{
    public class GetPetsOfClientQuery : IRequest<List<PetResponse>>
    {
        public Guid Id { get; set; }
    }
}
