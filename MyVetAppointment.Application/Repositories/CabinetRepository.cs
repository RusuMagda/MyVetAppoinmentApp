using Microsoft.EntityFrameworkCore;
using MyVetAppoinment.Domain.Entities;
using MyVetAppointment.Application;

namespace MyVetAppoinment.Repositories
{
    public class CabinetRepository : ICabinetRepository
    {
        private readonly IDatabaseContext context;
        public CabinetRepository(IDatabaseContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Cabinet cabinet)
        {
           await this.context.Cabinets.AddAsync(cabinet);
        }

        public void Update(Cabinet cabinet)
        {
            this.context.Cabinets.Update(cabinet);
        }

        public async void Delete(Guid id)
        {
            var cabinet = await this.context.Cabinets.FirstOrDefaultAsync(c => c.Id == id);
            if(cabinet != null)
            {
                this.context.Cabinets.Remove(cabinet);
            }
        }

        public async Task<IReadOnlyCollection<Cabinet>> GetAllAsync()
        {
            return await context.Cabinets.ToListAsync();
        }

        public async Task<Cabinet?> GetByIdAsync(Guid id)
        {
            return await context.Cabinets.FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task<IReadOnlyCollection<Client>> GetClientsAsync(Guid id)
        {
            var pets = await (context.Appointments.Where(a => a.CabinetId == id)).Select(a=> a.PetId).ToListAsync();

            List<Guid> ids=new List<Guid>();
            foreach(Guid q in pets)
                ids.Add(await context.Pets.Where(p=>p.Id==q).Select(p=>p.OwnerId).SingleAsync());

            List<Client> clients=new List<Client>();
            foreach (var cl in ids)
                clients.Add(await context.Clients.Where(c => c.Id == cl).SingleAsync());

            return clients;
        }
        public  async Task<IReadOnlyCollection<Cabinet>> GetCabinetsWithoutShop()
        {
            var shops=await (context.Shops.Select(a=>a.CabinetId).ToListAsync());
            List<Cabinet> cabs=new();
            var cab=await context.Cabinets.ToListAsync();


            foreach (var q in shops)
                cabs.Add(await context.Cabinets.Where(c=> c.Id==q).SingleAsync());
            foreach (var c in cabs.Where(c => cab.Contains(c)))
                cab.Remove(c);
            
           
            return cab;
        }


        public void Save()
        {
            context.SaveAsync();
        }
    }
}
