using MyVetAppointment.Domain.Entities;

namespace MyVetAppointment.Infrastructure.Repositories
{
    public interface IClientRepository
    {
        Task AddAsync(Client client);
        void Delete(Guid id);
        Task<Client?> GetByIdAsync(Guid id);
        Task<IReadOnlyCollection<Client>> GetAllAsync();
        Task<IReadOnlyCollection<Pet>> GetAllPetsAsync(Guid id);
        void Save();
        void Update(Client client);
    }
}