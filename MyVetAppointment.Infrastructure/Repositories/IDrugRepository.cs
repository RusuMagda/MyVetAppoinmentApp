using MyVetAppointment.Domain.Entities;

namespace MyVetAppointment.Infrastructure.Repositories
{
    public interface IDrugRepository
    {
        Task AddAsync(Drug drug);
        void Delete(Guid id);
        Task<Drug?> GetByIdAsync(Guid id);
        Task<IReadOnlyCollection<Drug>> GetAllAsync();
        Task<IReadOnlyCollection<Drug>> GetDrugsAsync(Guid id);
        void Save();
        void Update(Drug drug);
    }
}