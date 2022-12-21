using MediatR;
using MyVetAppointment.Application.Commands;
using MyVetAppointment.Application.Mappers;
using MyVetAppointment.Application.Response;
using MyVetAppointment.Domain.Entities;
using MyVetAppointment.Infrastructure.Repositories;

namespace MyVetAppointment.Application.Handlers
{
    public class CreatePetCommandHandler : IRequestHandler<CreatePetCommand, PetResponse>
    {
        private readonly IPetRepository repository;

        public CreatePetCommandHandler(IPetRepository repository)
        {
            this.repository = repository;
        }
        public async Task<PetResponse> Handle(CreatePetCommand request, CancellationToken cancellationToken)
        {
            var petEntity = PetMapper.Mapper.Map<Pet>(request);
            if (petEntity == null)
            {
                throw new ApplicationException("Issue with the Mapper");
            }

            await repository.AddAsync(petEntity);

            repository.Save();

            return PetMapper.Mapper.Map<PetResponse>(petEntity);

        }
    }
}
