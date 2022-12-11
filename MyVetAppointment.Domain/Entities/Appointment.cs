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
        
        public Appointment(Guid id, DateTime startTime, DateTime endTime, string description)
        {
            Id = id;
            StartTime = startTime;
            EndTime = endTime;
            Description = description;
        }

        public Guid Id { get; set; } = Guid.Empty;

        public Guid PetId { get; set; } = Guid.Empty;

        public DateTime StartTime { get; set; } = default(DateTime);
        public DateTime EndTime { get; set; } = default(DateTime);

        public string Description { get; set; } = String.Empty;

        public Guid CabinetId { get; set; } = Guid.Empty;

        public void attachPet(Guid id)
        {
            PetId = id;
        }

        public void attachCabinet(Guid id)
        {
            CabinetId = id;
        }

    }
}
