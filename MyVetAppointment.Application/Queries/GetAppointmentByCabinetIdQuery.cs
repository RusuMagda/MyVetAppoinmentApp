using MediatR;
using MyVetAppointment.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVetAppointment.Application.Queries
{
    public class GetAppointmentByCabinetIdQuery : IRequest<List<AppointmentResponse>>
    {
        public Guid cabinetId { get; set; }
      
    }
}
