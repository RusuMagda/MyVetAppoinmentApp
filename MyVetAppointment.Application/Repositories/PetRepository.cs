using MyVetAppoinment.Domain.Entities;
using MyVetAppointment.Application;

namespace MyVetAppoinment.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly IDatabaseContext context;

        public PetRepository(IDatabaseContext context)
        {
            this.context = context;
        }

        public void Add(Pet pet)
        {
            this.context.Pets.Add(pet);
        }

        public void Update(Pet pet)
        {
            this.context.Pets.Update(pet);
        }

        public void Delete(Pet pet)
        {
            this.context.Pets.Remove(pet);
        }

        public List<Pet> GetAll()
        {
            return context.Pets.ToList();
        }

        public Pet Get(Guid id)
        {
            return context.Pets.Find(id);
        }

        public List<Appointment> GetAppointments(Guid id)
        {
            return (context.Appointments.Where(a => a.PetId == id)).ToList();
        }

        public void Save()
        {
            context.Save();
        }
    }
}
