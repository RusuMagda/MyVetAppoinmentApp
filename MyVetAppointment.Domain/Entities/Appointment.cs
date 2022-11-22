namespace MyVetAppoinment.Domain.Entities
{
    public class Appointment
    {
        public Appointment(DateTime startTime, DateTime endTime, string description)
        {
            Id = Guid.NewGuid();
            StartTime = startTime;
            EndTime = endTime;
            Description = description;
        }

        public Guid Id { get; private set; } 

        public Pet Pet { get; private set; }

        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }

        public string Description { get; private set; }

        public Cabinet Cabinet { get; private set; }

    }
}
