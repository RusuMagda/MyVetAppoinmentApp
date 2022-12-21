using MediatR;
using MyVetAppointment.Application.Response;

namespace MyVetAppointment.Application.Commands
{
    public class DeletePetByIdCommand : IRequest<PetResponse>
    {
        public Guid Id { get; set; }
    }
}
