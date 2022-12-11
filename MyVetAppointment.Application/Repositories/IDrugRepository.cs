using MyVetAppoinment.Domain.Entities;

namespace MyVetAppoinment.Repositories
{
    public interface IDrugRepository
    {
        Task AddAsync(Drug drug);
        void Delete(Guid id);
        Task<Drug> GetByIdAsync(Guid id);
        Task<IReadOnlyCollection<Drug>> GetAllAsync();
        void Save();
        void Update(Drug drug);
    }
}