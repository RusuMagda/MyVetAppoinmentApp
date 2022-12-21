using MediatR;
using MyVetAppointment.Application.Commands;
using MyVetAppointment.Application.Mappers;
using MyVetAppointment.Application.Response;
using MyVetAppointment.Domain.Entities;
using MyVetAppointment.Infrastructure.Repositories;

namespace MyVetAppointment.Application.Handlers
{
    public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand, AppointmentResponse>
    {
        private readonly IAppointmentRepository repository;

        public CreateAppointmentCommandHandler(IAppointmentRepository repository)
        {
            this.repository = repository;
        }
        public async Task<AppointmentResponse> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appointmentEntity = AppointmentMapper.Mapper.Map<Appointment>(request);
            if (appointmentEntity == null)
            {
                throw new ApplicationException("Issue with the Mapper");
            }
            appointmentEntity.attachCabinet(request.CabinetId);
            appointmentEntity.attachPet(request.PetId);

            await repository.AddAsync(appointmentEntity);
            repository.Save();

            return AppointmentMapper.Mapper.Map<AppointmentResponse>(appointmentEntity);
        }
    }
}
