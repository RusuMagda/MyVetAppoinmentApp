using MediatR;
using MyVetAppointment.Application.Mappers;
using MyVetAppointment.Application.Response;
using MyVetAppointment.Infrastructure.Repositories;

namespace MyVetAppointment.Application.Queries
{
    public class GetPetsOfClientQueryHandler : IRequestHandler<GetPetsOfClientQuery, List<PetResponse>>
    {
        private readonly IPetRepository repository;

        public GetPetsOfClientQueryHandler(IPetRepository repository)
        {
            this.repository = repository;
        }
        public async Task<List<PetResponse>> Handle(GetPetsOfClientQuery request, CancellationToken cancellationToken)
        {
            var result = PetMapper.Mapper.Map<List<PetResponse>>(await repository.GetPetsClient(request.Id));
            return result;
        }
    }
}
