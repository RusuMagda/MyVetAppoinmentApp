using MyVetAppoinment.Entities;

namespace MyVetAppoinment.Repositories
{
    public interface IAppointmentRepository
    {
        void Add(Appointment appointment);
        void Delete(Appointment appointment);
        void Update(Appointment appointment);
    }
}