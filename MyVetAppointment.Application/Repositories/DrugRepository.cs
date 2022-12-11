using Microsoft.EntityFrameworkCore;
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

        public async Task AddAsync(Drug drug)
        {
            await this.context.Drugs.AddAsync(drug);
        }

        public void Update(Drug drug)
        {
            this.context.Drugs.Update(drug);
        }

        public async void Delete(Guid id)
        {
            var drug = await this.context.Drugs.FirstOrDefaultAsync(d => d.Id == id);
            if(drug != null)
            {
                this.context.Drugs.Remove(drug);
            }
        }

        public async Task<IReadOnlyCollection<Drug>> GetAllAsync()
        {
            return await context.Drugs.ToListAsync();
        }

        public async Task<Drug> GetByIdAsync(Guid id)
        {
            var result = await context.Drugs.FindAsync(id);
            if(result != null)
            {
                return result;
            }
            return null;
        }

        public void Save()
        {
            context.SaveAsync();
        }
    }
}
