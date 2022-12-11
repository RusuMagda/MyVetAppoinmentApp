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

        public void Add(Shop shop)
        {
            this.context.Shops.Add(shop);
        }

        public void Update(Shop shop)
        {
            this.context.Shops.Update(shop);
        }

        public void Delete(Shop shop)
        {
            this.context.Shops.Remove(shop);
        }

        public List<Shop> GetAll()
        {
            return context.Shops.ToList();
        }

        public Shop Get(Guid id)
        {
            return context.Shops.Find(id);
        }

        public void Save()
        {
            context.Save();
        }
    }
}
