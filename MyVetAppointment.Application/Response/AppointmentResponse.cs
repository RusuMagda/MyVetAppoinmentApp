namespace MyVetAppointment.Application.Response
{
    public class AppointmentResponse
    {
        public Guid Id { get;  set; }

        public Guid PetId { get;  set; } = Guid.Empty;

        public DateTime StartTime { get;  set; } = default(DateTime);
        public DateTime EndTime { get;  set; } = default(DateTime);

        public string Description { get;  set; } = String.Empty;

        public Guid CabinetId { get;  set; } = Guid.Empty;
    }
}
