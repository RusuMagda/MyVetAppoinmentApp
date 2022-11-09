
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

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Client> Clients { get; set; }
        public Shop Shop { get; set; }


    }
}
