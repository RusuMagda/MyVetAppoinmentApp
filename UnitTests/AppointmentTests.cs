using MyVetAppoinment.Domain.Entities;

namespace UnitTests
{
    public class AppointmentTest
    {
        [Fact]
        public void WhenAttachPet()
        {
            Appointment appointment = new Appointment(new DateTime(10 / 10 / 2022), new DateTime(11 / 10 / 2022), "consult");

            Assert.NotNull(appointment);

            var id = new Guid("bde0950c-fe42-417c-8b2a-4c49fd56215e");
            var OwnerId = new Guid();
            var name = "Dog";
            var birthdate = new DateTime(10 / 10 / 2010);
            var pet = new Pet(OwnerId, name, birthdate);
            appointment.attachPet(pet);

            appointment.PetId.Equals(pet.Id);
        }

        [Fact]
        public void WhenAttachCabinet()
        {
            Appointment appointment = new Appointment(new DateTime(10 / 10 / 2022), new DateTime(11 / 10 / 2022), "consult");

            Assert.NotNull(appointment);

            var cabinet = new Cabinet("ProVet", "Strada Smardan 84");
            appointment.attachCabinet(cabinet);

            appointment.CabinetId.Equals(cabinet.Id);
        }
    }
}
