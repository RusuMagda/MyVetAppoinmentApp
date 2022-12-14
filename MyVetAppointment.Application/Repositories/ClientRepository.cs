using Microsoft.EntityFrameworkCore;
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

        public async Task AddAsync(Client client)
        {
            await this.context.Clients.AddAsync(client);
        }

        public void Update(Client client)
        {
            this.context.Clients.Update(client);
        }

        public async void Delete(Guid id)
        {
            var client = await this.context.Clients.FirstOrDefaultAsync(c => c.Id == id);
            if(client != null)
            {
                this.context.Clients.Remove(client);
            }  
        }

        public async Task<IReadOnlyCollection<Client>> GetAllAsync()
        {
            return await context.Clients.ToListAsync();
        }

        public async Task<Client?> GetByIdAsync(Guid id)
        {
            return await context.Clients.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IReadOnlyCollection<Pet>> GetAllPetsAsync(Guid id)
        {
            return await (context.Pets.Where(p => p.OwnerId == id)).ToListAsync();
        }

        public void Save()
        {
            context.SaveAsync();
        }
    }
}
