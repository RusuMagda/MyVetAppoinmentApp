using MyVetAppoinment.Domain.Entities;

namespace MyVetAppoinment.Repositories
{
    public interface ICabinetRepository
    {
        Task AddAsync(Cabinet cabinet);
        void Delete(Guid id);
        Task<Cabinet?> GetByIdAsync(Guid id);
        Task<IReadOnlyCollection<Cabinet>> GetAllAsync();
        Task<IReadOnlyCollection<Client>> GetClientsAsync(Guid id);
        Task<IReadOnlyCollection<Cabinet>> GetCabinetsWithoutShop();
        void Save();
        void Update(Cabinet cabinet);
    }
}