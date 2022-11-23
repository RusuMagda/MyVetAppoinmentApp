namespace MyVetAppoinment.Domain.Entities
{
    public class Appointment
    {
        public Appointment(DateTime startTime, DateTime endTime, string description, Guid petId, Guid cabinetId)
        {
            Id = Guid.NewGuid();
            StartTime = startTime;
            EndTime = endTime;
            Description = description;
            PetId = petId;
            CabinetId = cabinetId;
        }

        public Guid Id { get; private set; } 

        public Guid PetId { get; private set; }

        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }

        public string Description { get; private set; }

        public Guid CabinetId { get; private set; }
/*
        public void attachPet(Pet pet)
        {
            PetId = pet.Id;
        }

        public void attachCabinet(Cabinet cabinet)
        {
            CabinetId = cabinet.Id;
        }*/

    }
}
