using MyVetAppoinment.Domain.Entities;

namespace MyVetAppoinment.Repositories
{
    public interface IShopRepository
    {
        Task AddAsync(Shop shop);
        void Delete(Guid id);
        Task<Shop?> GetByIdAsync(Guid id);
        Task<IReadOnlyCollection<Shop>> GetAllAsync();
        void Save();
        void Update(Shop shop);
    }
}