namespace MyVetAppoinment.Entities
{
    public class Pet
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}
