namespace MyVetAppoinment.Entities
{
    public class Appointment
    {
        public Appointment(int id, Pet pet, DateTime startTime, DateTime endTime, Cabinet cabinet)
        {
            Id = id;
            Pet = pet;
            StartTime = startTime;
            EndTime = endTime;
            Cabinet = cabinet;
        }

        public int Id { get; } 

        public Pet Pet { get; }

        public DateTime StartTime { get; }
        public DateTime EndTime { get; }

        public string Description { get; }

        public Cabinet Cabinet { get; }

    }
}
