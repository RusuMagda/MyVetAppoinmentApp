namespace MyVetAppoinment.Domain.Entities
{
    public class Pet
    {
        public Pet(int ownerId, string name, DateTime birthdate)
        {
            Id = Guid.NewGuid();
            OwnerId = ownerId;
            Name = name;
            Birthdate = birthdate;
        }

        public Guid Id { get; private set; }
        public int OwnerId { get; private set; }
        public string Name { get; private set; }
        public DateTime Birthdate { get; private set; }
        public List<Appointment> Appointments { get; private set; }

        public void addAppointment(Appointment appointment)
        {
            Appointments.Add(appointment);
        }
    }
}
