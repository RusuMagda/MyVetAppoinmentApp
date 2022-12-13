using Microsoft.EntityFrameworkCore;
using MyVetAppoinment.Domain.Entities;
using MyVetAppointment.Application;

namespace MyVetAppoinment.Repositories
{
    public class ShopRepository : IShopRepository
    {
        private readonly IDatabaseContext context;

        public ShopRepository(IDatabaseContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Shop shop)
        {
            await this.context.Shops.AddAsync(shop);
        }

        public void Update(Shop shop)
        {
            this.context.Shops.Update(shop);
        }

        public async void Delete(Guid id)
        {
            var shop = await this.context.Shops.FirstOrDefaultAsync(s => s.ShopId == id);
            if (shop != null)
            {
                this.context.Shops.Remove(shop);
            }
        }

        public async Task<IReadOnlyCollection<Shop>> GetAllAsync()
        {
            return await context.Shops.ToListAsync();
        }

        public async Task<Shop?> GetByIdAsync(Guid id)
        {
            return await this.context.Shops.FirstOrDefaultAsync(s => s.ShopId == id);
        }

        public void Save()
        {
            context.SaveAsync();
        }
    }
}
