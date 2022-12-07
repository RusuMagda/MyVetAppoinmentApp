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

        public Guid Id { get; private set; } = Guid.Empty;

        public Guid PetId { get; private set; } = Guid.Empty;

        public DateTime StartTime { get; private set; } = default(DateTime);
        public DateTime EndTime { get; private set; } = default(DateTime);

        public string Description { get; private set; } = String.Empty;

        public Guid CabinetId { get; private set; } = Guid.Empty;

        public void attachPet(Pet pet)
        {
            PetId = pet.Id;
        }

        public void attachCabinet(Cabinet cabinet)
        {
            CabinetId = cabinet.Id;
        }

    }
}
