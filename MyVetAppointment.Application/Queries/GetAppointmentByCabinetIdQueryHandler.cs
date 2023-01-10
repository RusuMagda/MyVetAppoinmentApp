using MediatR;
using MyVetAppointment.Application.Mappers;
using MyVetAppointment.Application.Response;
using MyVetAppointment.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVetAppointment.Application.Queries
{
    public class GetAppointmentByCabinetIdQueryHandler : IRequestHandler<GetAppointmentByCabinetIdQuery, List<AppointmentResponse>>
    {
        private readonly IAppointmentRepository repository;

        public GetAppointmentByCabinetIdQueryHandler(IAppointmentRepository repository)
        {
            this.repository = repository;
        }
        public async Task<List<AppointmentResponse>> Handle(GetAppointmentByCabinetIdQuery request, CancellationToken cancellationToken)
        {
            var result = AppointmentMapper.Mapper.Map<List<AppointmentResponse>>(await repository.GetByCabinetIdAsync(request.cabinetId));
            return result;
        }
       
    }
}
