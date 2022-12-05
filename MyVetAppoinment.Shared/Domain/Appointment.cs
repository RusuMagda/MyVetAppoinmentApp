using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVetAppoinment.Shared.Domain
{
    public class Appointment
    {
        public Guid Id { get;  set; }

        public Guid PetId { get;  set; }

        public DateTime StartTime { get;  set; }
        public DateTime EndTime { get;  set; }

        public string Description { get;  set; }

        public Guid CabinetId { get;  set; }
    }
}
