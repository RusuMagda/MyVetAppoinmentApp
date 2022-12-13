using MyVetAppoinment.Domain.Entities;

namespace MyVetAppoinment.Repositories
{
    public interface IAppointmentRepository
    {
        Task AddAsync(Appointment appointment);
        Task<Appointment?> GetByIdAsync(Guid id);
        Task<IReadOnlyCollection<Appointment>> GetAllAsync();
        void Delete(Guid id);
        void Update(Appointment appointment);
        void Save();
    }
}