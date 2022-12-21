using MediatR;
using MyVetAppointment.Application.Response;
using MyVetAppointment.Domain.Entities;

namespace MyVetAppointment.Application.Commands
{
    public class CreatePetCommand : IRequest<PetResponse>
    {
        public Guid OwnerId { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; } = default(DateTime);
    }
}
