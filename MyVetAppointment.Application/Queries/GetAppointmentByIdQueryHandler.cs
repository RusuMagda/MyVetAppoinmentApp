using MediatR;
using MyVetAppointment.Application.Mappers;
using MyVetAppointment.Application.Response;
using MyVetAppointment.Infrastructure.Repositories;

namespace MyVetAppointment.Application.Queries
{
    public class GetAppointmentByIdQueryHandler : IRequestHandler<GetAppointmentByIdQuery, AppointmentResponse>
    {
        private readonly IAppointmentRepository repository;

        public GetAppointmentByIdQueryHandler(IAppointmentRepository repository)
        {
            this.repository = repository;
        }
        public async Task<AppointmentResponse> Handle(GetAppointmentByIdQuery request, CancellationToken cancellationToken)
        {
            var result = AppointmentMapper.Mapper.Map<AppointmentResponse>(await repository.GetByIdAsync(request.Id));
            return result;
        }
    }
}
