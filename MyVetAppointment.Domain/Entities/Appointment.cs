namespace MyVetAppointment.Domain.Entities
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
        
        public Appointment(Guid id, DateTime startTime, DateTime endTime, string description)
        {
            Id = id;
            StartTime = startTime;
            EndTime = endTime;
            Description = description;
        }

        public Guid Id { get; private set; }

        public Guid PetId { get; private set; } = Guid.Empty;

        public DateTime StartTime { get; private set; } = default(DateTime);
        public DateTime EndTime { get; private set; } = default(DateTime);

        public string Description { get; private set; }

        public Guid CabinetId { get; private set; } = Guid.Empty;

        public void attachPet(Guid id)
        {
            PetId = id;
        }

        public void attachCabinet(Guid id)
        {
            CabinetId =  id;
        }

    }
}
