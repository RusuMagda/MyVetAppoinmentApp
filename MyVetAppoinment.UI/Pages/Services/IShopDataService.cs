using MyVetAppoinment.Shared.Domain;

namespace MyVetAppoinment.UI.Pages.Services
{
    public interface IShopDataService
    {
        Task<IEnumerable<Shop>?> GetAllShops();
       
        Task<Shop?> GetShopDetail(Guid shopId);

        Task<IEnumerable<Drug>> GetShopDrugs(Guid shopId);
        void AddShop(Shop shop);
        void EditShop(Guid shopId, Shop shop);
        void DeleteShop(Guid shopId);
    }
}
