using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyVetAppointment.Application.Response;

namespace MyVetAppointment.Application.Commands
{
    public class CreateAppointmentCommand : IRequest<AppointmentResponse>
    {
        public Guid PetId { get;  set; } = Guid.Empty;

        public DateTime StartTime { get;  set; } = default(DateTime);
        public DateTime EndTime { get; set; } = default(DateTime);

        public string Description { get; set; } = string.Empty;

        public Guid CabinetId { get;  set; } = Guid.Empty;
    }
}
