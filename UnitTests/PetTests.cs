using MyVetAppoinment.Domain.Entities;
using System;

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
        public void WhenAddAppointment()
        {
            Appointment appointment = new Appointment(new DateTime(10 / 10 / 2022), new DateTime(11 / 10 / 2022), "consult");
            var OwnerId = new Guid();
            var name = "Dog";
            var birthdate = new DateTime(10 / 10 / 2010);
            Pet myPet = new Pet(OwnerId, name, birthdate);

            Assert.NotNull(myPet);

            myPet.addAppointment(appointment);

            myPet.Appointments.Count.Equals(1);
            myPet.Appointments[0].Equals(appointment);
        }

    }
}
