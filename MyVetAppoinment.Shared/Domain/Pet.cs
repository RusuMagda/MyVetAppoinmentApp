using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVetAppoinment.Shared.Domain
{
    public class Pet
    {
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}
