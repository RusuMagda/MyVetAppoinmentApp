using MyVetAppoinment.Domain.Entities;

namespace MyVetAppoinment.Repositories
{
    public interface IAppointmentRepository
    {
        void Add(Appointment appointment);
        void Delete(Appointment appointment);
        Appointment Get(Guid id);
        List<Appointment> GetAll();
        void Save();
        void Update(Appointment appointment);
    }
}