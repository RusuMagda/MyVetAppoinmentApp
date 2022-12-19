
using MyVetAppointment.Domain.Entities;

namespace UnitTests
{
    public class CabinetTests
    {
        [Fact]
        public void WhenInitializeCabinetWithId()
        {
            var Id = new Guid("086771a1-4a3b-4a64-b922-00b7bbe54fdf");
            var name = "ProVet";
            var address = "Strada Smardan 84";
            var description = "New Cabinet";
            var phoneNumber = "0123456789";
            var img = "image.png";
            Cabinet result = new Cabinet(Id, name, address,description,phoneNumber, img);

            Assert.NotNull(result);
            result.Id.Equals(new Guid("086771a1-4a3b-4a64-b922-00b7bbe54fdf"));
            result.Name.Equals("ProVet");
            result.Address.Equals("Strada Smardan 84");
            result.Description.Equals("New Cabinet");
            result.PhoneNumber.Equals("0123456789");
            result.Image.Equals("image.png");
        }

        [Fact]
        public void WhenAddClient()
        {
            Cabinet result = new Cabinet("ProVet", "Strada Smardan 84");
            Assert.NotNull(result);

            Client client = new Client("oana", "oana@yahoo.com", "0123456789");
            result.addClient(client);
            result.Clients.Count.Equals(1);
            result.Clients[0].Equals(client);
        }

        [Fact]
        public void WhenAttachShop()
        {
            Cabinet cabinet = new Cabinet("ProVet", "Strada Smardan 84");
            Assert.NotNull(cabinet);

            var shop = new Shop("MyShop", new Guid("d42fbb91-0ebe-43ea-b91c-b9b026430f09"));
            Assert.NotNull(shop);
            cabinet.attachShop(shop);

            cabinet.Shop.Equals(shop);
        }
    }
}
