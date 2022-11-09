using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVetAppoinment.Entities
{
    public class Appointment
    {
        public int Id { get; set; } 

        public Pet Pet { get; set; }

        public DateTime DateAndHour { get; set; }

        public Cabinet Cabinet { get; set; }

    }
}
