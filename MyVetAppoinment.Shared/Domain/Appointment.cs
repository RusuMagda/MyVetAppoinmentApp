namespace MyVetAppoinment.Shared.Domain
{
    public class Appointment
    {
        public Guid Id { get;  set; } = Guid.Empty;

        public Guid PetId { get;  set; } = Guid.Empty;

        public DateTime StartTime { get;  set; } = default(DateTime);
        public DateTime EndTime { get;  set; } = default(DateTime);

        public string Description { get;  set; } = String.Empty;

        public Guid CabinetId { get;  set; } = Guid.Empty;
    }
}
