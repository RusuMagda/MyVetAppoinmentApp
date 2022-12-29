namespace MyVetAppointment.Application.Response
{
    public class PetResponse
    {
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; } = default(DateTime);
    }
}
