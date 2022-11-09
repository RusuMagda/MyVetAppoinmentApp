using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVetAppoinment.Entities
{
    public class Appointment
    {
        public Appointment(int id, Pet pet, DateTime dateAndHour, Cabinet cabinet)
        {
            Id = id;
            Pet = pet;
            DateAndHour = dateAndHour;
            Cabinet = cabinet;
        }

        public int Id { get; set; } 

        public Pet Pet { get; set; }

        public DateTime DateAndHour { get; set; }

        public Cabinet Cabinet { get; set; }

    }
}
