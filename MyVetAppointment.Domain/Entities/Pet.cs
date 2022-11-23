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

        public Guid Id { get;  set; }
        public int OwnerId { get;  set; }
        public string Name { get;  set; }
        public DateTime Birthdate { get;  set; }
        public List<Appointment> Appointments { get;  set; }

        public void addAppointment(Appointment appointment)
        {
            Appointments.Add(appointment);
        }
    }
}
