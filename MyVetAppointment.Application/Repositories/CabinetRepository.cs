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

        public void Save()
        {
            context.Save();
        }
    }
}
