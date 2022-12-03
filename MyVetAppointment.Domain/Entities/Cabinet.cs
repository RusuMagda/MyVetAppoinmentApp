
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

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Address { get; private set; }
        public List<Client> Clients { get; private set; }
        public Shop Shop { get; private set; }

        public void addClient(Client client)
        {
            Clients.Add(client);
        }

        public void attachShop(Shop shop)
        {
            Shop = shop;
        }
    }
}
