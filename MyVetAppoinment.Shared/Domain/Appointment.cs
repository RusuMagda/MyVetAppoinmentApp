namespace MyVetAppoinment.Shared.Domain
{
    public class Appointment
    {
        public Guid Id { get; private set; } = Guid.Empty;

        public Guid PetId { get; private set; } = Guid.Empty;

        public DateTime StartTime { get; private set; } = default(DateTime);
        public DateTime EndTime { get; private set; } = default(DateTime);

        public string Description { get; private set; } = String.Empty;

        public Guid CabinetId { get; private set; } = Guid.Empty;
    }
}
