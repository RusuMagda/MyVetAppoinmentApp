using MyVetAppointment.Domain.Entities;

namespace UnitTests
{
    public class AppointmentTest
    {
        [Fact]
        public void WhenCreateAppointmentWithId()
        {
            var id = new Guid("401ce3ad-cccd-4126-8067-55fb320ab637");
            var startTime = new DateTime(01/01/2023);
            var endTime = new DateTime(02/01/2023);
            var description = "control";
            Appointment appointment = new Appointment(id, startTime, endTime, description);

            Assert.NotNull(appointment);
            appointment.Id.Equals(new Guid("401ce3ad-cccd-4126-8067-55fb320ab637"));
            appointment.StartTime.Equals(new DateTime(01 / 01 / 2023));
            appointment.EndTime.Equals(new DateTime(02 / 01 / 2023));
            appointment.Description.Equals("control");
        }
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
            appointment.AttachPet(pet.Id);

            appointment.PetId.Equals(pet.Id);
        }

        [Fact]
        public void WhenAttachCabinet()
        {
            Appointment appointment = new Appointment(new DateTime(10 / 10 / 2022), new DateTime(11 / 10 / 2022), "consult");

            Assert.NotNull(appointment);

            var cabinet = new Cabinet("ProVet", "Strada Smardan 84");
            appointment.AttachCabinet(cabinet.Id);

            appointment.CabinetId.Equals(cabinet.Id);
        }
    }
}
