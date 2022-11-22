namespace MyVetAppoinment.Repositories
{
    public class ShopRepository : IShopRepository
    {
        private readonly MyVetAppointmentDatabaseContext context;

        public ShopRepository(MyVetAppointmentDatabaseContext context)
        {
            this.context = context;
        }

        public void Add(Shop shop)
        {
            this.context.Shops.Add(shop);
            this.context.SaveChanges();
        }

        public void Update(Shop shop)
        {
            this.context.Shops.Update(shop);
            this.context.SaveChanges();
        }

        public void Delete(Shop shop)
        {
            this.context.Shops.Remove(shop);
            this.context.SaveChanges();
        }
    }
}
