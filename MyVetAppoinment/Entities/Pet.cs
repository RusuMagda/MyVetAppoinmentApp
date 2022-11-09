namespace MyVetAppoinment.Entities
{
    public class Pet
    {
        public Pet(int id, int ownerId, string name, DateTime birthdate, List<Appointment> appointments)
        {
            Id = id;
            OwnerId = ownerId;
            Name = name;
            Birthdate = birthdate;
            Appointments = appointments;
        }

        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}
