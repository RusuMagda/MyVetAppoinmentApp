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

        public void Add(Cabinet cabinet)
        {
            this.context.Cabinets.Add(cabinet);
        }

        public void Update(Cabinet cabinet)
        {
            this.context.Cabinets.Update(cabinet);
        }

        public void Delete(Cabinet cabinet)
        {
            this.context.Cabinets.Remove(cabinet);
        }

        public List<Cabinet> GetAll()
        {
            return context.Cabinets.ToList();
        }

        public Cabinet Get(Guid id)
        {
            return context.Cabinets.Find(id);
        }
        public List<Client> GetClients(Guid id)
        {
            var pets=(context.Appointments.Where(a => a.CabinetId == id)).Select(a=> a.PetId).ToList();
           List<Guid> ids=new List<Guid>();
            foreach(Guid q in pets)
                ids.Add(context.Pets.Where(p=>p.Id==q).Select(p=>p.OwnerId).Single());
            List<Client> clients=new List<Client>();
            foreach (Guid cl in ids)
                clients.Add(context.Clients.Where(c => c.Id == cl).Single());
            return clients;

        }

        public void Save()
        {
            context.Save();
        }
    }
}
