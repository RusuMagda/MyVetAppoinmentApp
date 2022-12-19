
namespace MyVetAppointment.Domain.Entities
{
    public class Cabinet
    {
        
        public Cabinet(string name, string address,string description,string phonenumber,string img)
        {
            Id = Guid.NewGuid();
            Name = name;
            Address = address;
            Description= description;
            PhoneNumber= phonenumber;
            Image= img;
        }
        public Cabinet(Guid id,string name, string address, string description, string phonenumber, string img)
        {
            Id = id;
            Name = name;
            Address = address;
            Description = description;
            PhoneNumber = phonenumber;
            Image= img;
        }
        public Cabinet(Guid id, string name, string address) { 
            Id = id;
            Name = name;
            Address = address;
            
        }
        public Cabinet(string name, string address)
        {
            Id = Guid.NewGuid();
            Name = name;
            Address = address;

        }


        public Guid Id { get; private set; }
        public string Name { get;  set; }
        public string Address { get; set; }
        public string Description { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public List<Client> Clients { get; private set; } = new List<Client>();
        public Shop Shop { get; private set; } = default!;

        public void addClient(Client client)
        {
            if (Clients == null) Clients = new List<Client>();
            Clients.Add(client);
        }

        public void attachShop(Shop shop)
        {
            Shop = shop;
        }
    }
}
