namespace MyVetAppoinment.Domain.Entities
{
    public class Client
    {
        public Client(string name, string eMail, string phoneNumber)
        {
            Id = Guid.NewGuid();
            Name = name;
            EMail = eMail;
            PhoneNumber = phoneNumber;
        }

        public Client(Guid id, string name, string eMail, string phoneNumber)
        {
            Id = id;
            Name = name;
            EMail = eMail;
            PhoneNumber = phoneNumber;
        }

        public Guid Id { get;  set; }

        public string Name { get; set; } 

        public List<Pet> Pets { get; set; } = new List<Pet>();

        public string EMail { get; set; }

        public string PhoneNumber { get; set; }

        public void addPet(Pet pet)
        {
            if (Pets == null) Pets = new List<Pet>();
            Pets.Add(pet);
        }
    }
}
