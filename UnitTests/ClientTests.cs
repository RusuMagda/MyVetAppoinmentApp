using MyVetAppointment.Domain.Entities;

namespace UnitTests
{
    public class ClientTests
    {
        [Fact]
        public void WhenInitializeClientWithId()
        {
            var Id = new Guid("3837a85c-fc53-40d9-b588-2fd95fa86518");
            var name = "oana";
            var email = "oana@yahoo.com";
            var phoneNumber = "0123456789";
            Client client = new Client(Id, name, email, phoneNumber);

            Assert.NotNull(client);
            client.Id.Equals(new Guid("3837a85c-fc53-40d9-b588-2fd95fa86518"));
            client.Name.Equals("oana");
            client.EMail.Equals("oana@yahoo.com");
            client.PhoneNumber.Equals("0123456789");
        }

        [Fact]
        public void WhenAddPet()
        {
            Client client = new Client("oana", "oana@yahoo.com", "0123456789");
            Assert.NotNull(client);

            Pet pet = new Pet(client.Id, "Dog", new DateTime(10 / 10 / 2015));
            client.addPet(pet);
            client.Pets.Count.Equals(1);
            client.Pets[0].Equals(pet);
        }
    }
}
