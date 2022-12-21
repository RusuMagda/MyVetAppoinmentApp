using MyVetAppointment.Domain.Entities;

namespace UnitTests
{
    public class PetTests
    {

        [Fact]
        public void WhenInitializePet()
        {
            var OwnerId = new Guid();
            var name = "Dog";
            var birthdate = new DateTime(10 / 10 / 2010);
            var result = new Pet(OwnerId, name, birthdate);

            Assert.NotNull(result);
            result.Name.Equals("Dog");
            result.Birthdate.Equals(new DateTime(10 / 10 / 2010));
        }

        [Fact]
        public void WhenInitializePetWithId()
        {
            var petId = new Guid("9074d219-a6a1-43c0-808d-c717e0c95c49");
            var OwnerId = new Guid();
            var name = "Dog";
            var birthdate = new DateTime(10 / 10 / 2010);
            var result = new Pet(petId, OwnerId, name, birthdate);

            Assert.NotNull(result);
            result.Name.Equals("Dog");
            result.Id.Equals(new Guid("9074d219-a6a1-43c0-808d-c717e0c95c49"));
            result.OwnerId.Equals(OwnerId);
            result.Birthdate.Equals(new DateTime(10 / 10 / 2010));
        }
    }
}
