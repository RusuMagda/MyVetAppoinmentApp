using MyVetAppoinment.Domain.Entities;

namespace MyVetAppoinment.Repositories
{
    public interface IClientRepository
    {
        void Add(Client client);
        void Delete(Client client);
        Client Get(Guid id);
        List<Client> GetAll();
        List<Pet> GetAllPets(Guid id);
        void Save();
        void Update(Client client);
    }
}