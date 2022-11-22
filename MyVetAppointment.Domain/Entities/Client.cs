namespace MyVetAppoinment.Domain.Entities
{
    public class Client
    {
        public Client(string name, string eMail, int phoneNumber)
        {
            Id = Guid.NewGuid();
            Name = name;
            EMail = eMail;
            PhoneNumber = phoneNumber;
        }

        public Guid Id { get; private set; } 

        public string Name { get; private set; }    

        public List<Pet> Pets { get; private set; }

        public string EMail { get; private set; }

        public int PhoneNumber { get; private set; }

        public void addPet(Pet pet)
        {
            Pets.Add(pet);
        }
    }
}
