namespace MyVetAppointment.API.DTOs
{
    public class CreatePetDto
    {
        public int OwnerId { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
