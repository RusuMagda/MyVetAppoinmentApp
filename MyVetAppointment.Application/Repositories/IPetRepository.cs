using MyVetAppoinment.Domain.Entities;

namespace MyVetAppoinment.Repositories
{
    public interface IPetRepository
    {
        void Add(Pet pet);
        void Delete(Pet pet);
        Pet Get(Guid id);
        List<Pet> GetAll();
        List<Appointment> GetAppointments(Guid id);
        void Save();
        void Update(Pet pet);
    }
}