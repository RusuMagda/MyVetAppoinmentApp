using MyVetAppoinment.Domain.Entities;
using MyVetAppointment.Application;

namespace MyVetAppoinment.Repositories
{
    public class DrugRepository : IDrugRepository
    {
        private readonly IDatabaseContext context;

        public DrugRepository(IDatabaseContext context)
        {
            this.context = context;
        }

        public void Add(Drug drug)
        {
            this.context.Drugs.Add(drug);
        }

        public void Update(Drug drug)
        {
            this.context.Drugs.Update(drug);
        }

        public void Delete(Drug drug)
        {
            this.context.Drugs.Remove(drug);
        }

        public List<Drug> GetAll()
        {
            return context.Drugs.ToList();
        }

        public Drug Get(Guid id)
        {
            return context.Drugs.Find(id);
        }

        public void Save()
        {
            context.Save();
        }
    }
}
