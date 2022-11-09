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

        public int Id { get; } 

        public Pet Pet { get; }

        public DateTime DateAndHour { get; }

        public string Description { get; }

        public Cabinet Cabinet { get; }

    }
}
