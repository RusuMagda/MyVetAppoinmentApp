using MyVetAppoinment.Domain.Entities;
using MyVetAppointment.Application;

namespace MyVetAppoinment.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly IDatabaseContext context;

        public ClientRepository(IDatabaseContext context)
        {
            this.context = context;
        }

        public void Add(Client client)
        {
            this.context.Clients.Add(client);
        }

        public void Update(Client client)
        {
            this.context.Clients.Update(client);
        }

        public void Delete(Client client)
        {
            this.context.Clients.Remove(client);
        }

        public List<Client> GetAll()
        {
            return context.Clients.ToList();
        }

        public Client Get(Guid id)
        {
            return context.Clients.Find(id);
        }

        public List<Pet> GetAllPets(Guid id)
        {
            return (context.Pets.Where(p => p.OwnerId == id)).ToList();
        }

        public void Save()
        {
            context.Save();
        }
    }
}
