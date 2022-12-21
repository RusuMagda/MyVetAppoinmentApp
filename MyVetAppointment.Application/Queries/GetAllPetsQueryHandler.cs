using MediatR;
using MyVetAppointment.Application.Mappers;
using MyVetAppointment.Application.Response;
using MyVetAppointment.Infrastructure.Repositories;

namespace MyVetAppointment.Application.Queries
{
    public class GetAllPetsQueryHandler : IRequestHandler<GetAllPetsQuery, List<PetResponse>>
    {
        private readonly IPetRepository repository;

        public GetAllPetsQueryHandler(IPetRepository repository)
        {
            this.repository = repository;
        }
        public async Task<List<PetResponse>> Handle(GetAllPetsQuery request, CancellationToken cancellationToken)
        {
            var result = PetMapper.Mapper.Map<List<PetResponse>>(await repository.GetAllAsync());
            return result;
        }
    }
}
