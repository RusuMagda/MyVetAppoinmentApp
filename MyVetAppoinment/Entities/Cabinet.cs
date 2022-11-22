
namespace MyVetAppoinment.Entities
{
    public class Cabinet
    {
        public Cabinet(int id, string name, string address, List<Client> clients, Shop shop)
        {
            Id = id;
            Name = name;
            Address = address;
            Clients = clients;
            Shop = shop;
        }

        public int Id { get; }
        public string Name { get; }
        public string Address { get; }
        public List<Client> Clients { get; }
        public Shop Shop { get; }

        public void addClient(Client client)
        {
            Clients.Add(client);
        }
    }
}
