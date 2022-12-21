using MediatR;
using MyVetAppointment.Application.Mappers;
using MyVetAppointment.Application.Response;
using MyVetAppointment.Infrastructure.Repositories;

namespace MyVetAppointment.Application.Queries
{
    public class GetAllAppointmentsQueryHandler : IRequestHandler<GetAllAppointmentsQuery, List<AppointmentResponse>>
    {
        private readonly IAppointmentRepository repository;

        public GetAllAppointmentsQueryHandler(IAppointmentRepository repository)
        {
            this.repository = repository;
        }
        public async Task<List<AppointmentResponse>> Handle(GetAllAppointmentsQuery request, CancellationToken cancellationToken)
        {
            var result = AppointmentMapper.Mapper.Map<List<AppointmentResponse>>(await repository.GetAllAsync());
            return result;
        }
    }
}
