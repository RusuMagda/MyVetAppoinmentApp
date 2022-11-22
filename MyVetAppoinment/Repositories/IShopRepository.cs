namespace MyVetAppoinment.Repositories
{
    public interface IShopRepository
    {
        void Add(Shop shop);
        void Delete(Shop shop);
        void Update(Shop shop);
    }
}