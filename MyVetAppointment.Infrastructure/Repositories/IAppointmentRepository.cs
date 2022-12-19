using MyVetAppointment.Domain.Entities;

namespace MyVetAppointment.Infrastructure.Repositories
{
    public interface IAppointmentRepository
    {
        Task AddAsync(Appointment appointment);
        Task<Appointment?> GetByIdAsync(Guid id);
        Task<IReadOnlyCollection<Appointment>> GetAllAsync();
        void Delete(Guid id);
        void Save();
    }
}