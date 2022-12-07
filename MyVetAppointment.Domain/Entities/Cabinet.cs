
namespace MyVetAppoinment.Domain.Entities
{
    public class Cabinet
    {
        public Cabinet(string name, string address)
        {
            Id = Guid.NewGuid();
            Name = name;
            Address = address;
        }
        public Cabinet(Guid id, string name, string address)
        {
            Id = id;
            Name = name;
            Address = address;
        }

        public Guid Id { get; private set; } = Guid.Empty;
        public string Name { get;  set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
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
