namespace MyVetAppointment.API.DTOs
{
    public class CreatePetDto
    {
        public Guid OwnerId { get; set; } = Guid.Empty;
        public string Name { get; set; } = string.Empty;
        public DateTime Birthdate { get; set; } = default(DateTime);
    }
}
