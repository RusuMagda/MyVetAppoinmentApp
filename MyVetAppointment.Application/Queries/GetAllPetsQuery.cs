using MediatR;
using MyVetAppointment.Application.Response;

namespace MyVetAppointment.Application.Queries
{
    public class GetAllPetsQuery : IRequest<List<PetResponse>>
    {
    }
}
