using MyVetAppoinment.Domain.Entities;

namespace MyVetAppoinment.Repositories
{
    public interface IShopRepository
    {
        void Add(Shop shop);
        void Delete(Shop shop);
        Shop Get(Guid id);
        List<Shop> GetAll();
        void Save();
        void Update(Shop shop);
    }
}