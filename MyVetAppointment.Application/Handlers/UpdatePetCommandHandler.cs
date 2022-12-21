using MediatR;
using MyVetAppointment.Application.Commands;
using MyVetAppointment.Application.Mappers;
using MyVetAppointment.Application.Response;
using MyVetAppointment.Domain.Entities;
using MyVetAppointment.Infrastructure.Repositories;

namespace MyVetAppointment.Application.Handlers
{
    public class UpdatePetCommandHandler : IRequestHandler<UpdatePetCommand, Guid>
    {
        private readonly IPetRepository repository;

        public UpdatePetCommandHandler(IPetRepository repository)
        {
            this.repository = repository;
        }
        public async Task<Guid> Handle(UpdatePetCommand request, CancellationToken cancellationToken)
        {
            var pet = PetMapper.Mapper.Map<Pet>(await repository.GetByIdAsync(request.Id));
            if (pet == null)
            {
                throw new ApplicationException("Pet not found");
            }
            pet.OwnerId = request.OwnerId;
            pet.Birthdate = request.Birthdate;
            pet.Name = request.Name;
            repository.Update(PetMapper.Mapper.Map<Pet>(pet));
            repository.Save();
            return pet.Id;
        }
    }
}
