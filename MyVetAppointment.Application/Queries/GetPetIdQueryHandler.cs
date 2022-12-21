using MediatR;
using MyVetAppointment.Application.Mappers;
using MyVetAppointment.Application.Response;
using MyVetAppointment.Infrastructure.Repositories;

namespace MyVetAppointment.Application.Queries
{
    public class GetPetIdQueryHandler : IRequestHandler<GetPetIdQuery, PetResponse>
    {
        private readonly IPetRepository repository;

        public GetPetIdQueryHandler(IPetRepository repository)
        {
            this.repository = repository;
        }
        
        public async Task<PetResponse> Handle(GetPetIdQuery request, CancellationToken cancellationToken)
        {
            var result = PetMapper.Mapper.Map<PetResponse>(await repository.GetPetId(request.Id, request.Name));
            return result;
        }
    }
}
