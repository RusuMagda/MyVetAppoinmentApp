namespace MyVetAppointment.Domain.Entities
{
    public class Pet
    {
        public Pet(Guid ownerId, string name, DateTime birthdate)
        {
            Id = Guid.NewGuid();
            OwnerId = ownerId;
            Name = name;
            Birthdate = birthdate;
        }
        
        public Pet(Guid id, Guid ownerId, string name, DateTime birthdate)
        {
            Id = id;
            OwnerId = ownerId;
            Name = name;
            Birthdate = birthdate;
        }

        public Guid Id { get;  set; }
        public Guid OwnerId { get; set; }
        public string Name { get;  set; }
        public DateTime Birthdate { get; set; } = default(DateTime);
    }
}







