
namespace MyVetAppoinment.Entities
{
    public class Cabinet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Client> Clients { get; set; }
        public Shop Shop { get; set; }


    }
}
