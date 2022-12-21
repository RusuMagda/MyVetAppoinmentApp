using MediatR;
using MyVetAppointment.Application.Commands;
using MyVetAppointment.Application.Mappers;
using MyVetAppointment.Application.Response;
using MyVetAppointment.Infrastructure.Repositories;

namespace MyVetAppointment.Application.Handlers
{
    public class DeleteAppointmentByIdCommandHandler : IRequestHandler<DeleteAppointmentByIdCommand, AppointmentResponse>
    {
        private readonly IAppointmentRepository repository;

        public DeleteAppointmentByIdCommandHandler(IAppointmentRepository repository)
        {
            this.repository = repository;
        }
        public async Task<AppointmentResponse> Handle(DeleteAppointmentByIdCommand request, CancellationToken cancellationToken)
        {
            var appointment = AppointmentMapper.Mapper.Map<AppointmentResponse>(await repository.GetByIdAsync(request.Id));
            if (appointment == null)
            {
                throw new ApplicationException("Appointment not found");
            }

            repository.Delete(request.Id);
            repository.Save();
            return appointment;
        }
    }
}
