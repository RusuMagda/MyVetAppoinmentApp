using MyVetAppoinment.Shared.Domain;

namespace MyVetAppoinment.UI.Pages.Services
{
    public interface ICabinetDataService
    {
        Task<IEnumerable<Cabinet>?> GetAllCabinets();
        Task<IEnumerable<Cabinet>?> GetCabinetsWithoutShop();
        Task<IEnumerable<Client>?> GetAllClients(Guid cabinetId);
        Task<Cabinet?> GetCabinetDetail(Guid cabinetId);
        

        void AddCabinet(Cabinet cabinet);
        void EditCabinet(Guid cabinetId,Cabinet cabinet);
        void DeleteCabinet(Guid cabinetId);
    }
}
