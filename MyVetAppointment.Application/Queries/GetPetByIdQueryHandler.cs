using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using MyVetAppointment.Application.Mappers;
using MyVetAppointment.Application.Response;
using MyVetAppointment.Infrastructure.Repositories;

namespace MyVetAppointment.Application.Queries
{
    public class GetPetByIdQueryHandler : IRequestHandler<GetPetByIdQuery, PetResponse>
    {
            private readonly IPetRepository repository;

            public GetPetByIdQueryHandler(IPetRepository repository)
            {
                this.repository = repository;
            }

            public async Task<PetResponse> Handle(GetPetByIdQuery request, CancellationToken cancellationToken)
            {
                var result = PetMapper.Mapper.Map<PetResponse>(await repository.GetByIdAsync(request.Id));
                return result;
            }
    }
}
