using MediatR;
using MyVetAppointment.Application.Commands;
using MyVetAppointment.Application.Mappers;
using MyVetAppointment.Application.Response;
using MyVetAppointment.Infrastructure.Repositories;

namespace MyVetAppointment.Application.Handlers
{
    public class DeletePetByIdCommandHandler : IRequestHandler<DeletePetByIdCommand, PetResponse>
    {
        private readonly IPetRepository repository;

        public DeletePetByIdCommandHandler(IPetRepository repository)
        {
            this.repository = repository;
        }
        public async Task<PetResponse> Handle(DeletePetByIdCommand request, CancellationToken cancellationToken)
        {
            var pet = PetMapper.Mapper.Map<PetResponse>(await repository.GetByIdAsync(request.Id));
            if (pet == null)
            {
                throw new ApplicationException("Pet not found");
            }

            repository.Delete(request.Id);
            repository.Save();
            return pet;
        }
    }
}
