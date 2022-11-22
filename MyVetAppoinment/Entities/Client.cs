namespace MyVetAppoinment.Entities
{
    public class Client
    {
        public Client(int id, string name, List<Pet> pets, string eMail, int phoneNumber)
        {
            Id = id;
            Name = name;
            Pets = pets;
            EMail = eMail;
            PhoneNumber = phoneNumber;
        }

        public int Id { get; } 

        public string Name { get; }    

        public List<Pet> Pets { get; }

        public string EMail { get; }

        public int PhoneNumber { get; }

        public void addPet(Pet pet)
        {
            Pets.Add(pet);
        }
    }
}
