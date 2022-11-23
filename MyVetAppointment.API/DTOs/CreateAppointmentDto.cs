namespace MyVetAppointment.API.DTOs
{
    public class CreateAppointmentDto
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
    }
}
