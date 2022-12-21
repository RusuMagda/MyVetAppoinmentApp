using MediatR;
using MyVetAppointment.Application.Response;

namespace MyVetAppointment.Application.Queries
{
    public class GetPetByIdQuery : IRequest<PetResponse>
    {
        public Guid Id { get; set; }
    }
}
