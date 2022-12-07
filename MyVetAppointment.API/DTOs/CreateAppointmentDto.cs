namespace MyVetAppointment.API.DTOs
{
    public class CreateAppointmentDto
    {
        public DateTime StartTime { get; set; } = default(DateTime);
        public DateTime EndTime { get; set; } = default(DateTime);
        public string Description { get; set; } = string.Empty; 
    }
}
