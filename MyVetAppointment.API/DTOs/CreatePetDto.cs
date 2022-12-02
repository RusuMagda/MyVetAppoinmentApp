namespace MyVetAppointment.API.DTOs
{
    public class CreatePetDto
    {
        public Guid OwnerId { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
