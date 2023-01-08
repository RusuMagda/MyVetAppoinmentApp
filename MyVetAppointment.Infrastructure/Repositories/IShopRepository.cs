using MyVetAppointment.Domain.Entities;

namespace MyVetAppointment.Infrastructure.Repositories
{
    public interface IShopRepository
    {
        Task AddAsync(Shop shop);
        void Delete(Guid id);
        Task<Shop?> GetByIdAsync(Guid id);
        Task<IReadOnlyCollection<Shop>> GetAllAsync();

        Task<IReadOnlyCollection<Drug>> GetShopDrugsAsync(Guid id);
        void Save();
        void Update(Shop shop);
    }
}