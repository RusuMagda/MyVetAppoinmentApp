using MediatR;
using MyVetAppointment.Application.Response;

namespace MyVetAppointment.Application.Commands
{
    public class UpdatePetCommand : IRequest<PetResponse>
    {
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; } = default(DateTime);
    }
}
