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

        public int Id { get; }
        public int OwnerId { get; }
        public string Name { get; }
        public DateTime Birthdate { get; }
        public List<Appointment> Appointments { get; }
    }
}
