using MediatR;
using MyVetAppointment.Application.Mappers;
using MyVetAppointment.Application.Response;
using MyVetAppointment.Domain.Entities;
using MyVetAppointment.Infrastructure.Repositories;

namespace MyVetAppointment.Application.Queries
{
    public class GetPetAppointmentsQueryHandler : IRequestHandler<GetPetAppointmentsQuery, List<AppointmentResponse>>
    {
        private readonly IPetRepository repository;

        public GetPetAppointmentsQueryHandler(IPetRepository repository)
        {
            this.repository = repository;
        }
        public async Task<List<AppointmentResponse>> Handle(GetPetAppointmentsQuery request, CancellationToken cancellationToken)
        {
            var response =
                AppointmentMapper.Mapper.Map<List<AppointmentResponse>>(await repository.GetAppointmentsAsync(request.Id));
            return response;
        }
    }
}