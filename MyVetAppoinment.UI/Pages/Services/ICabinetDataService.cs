using MyVetAppoinment.Shared.Domain;

namespace MyVetAppoinment.UI.Pages.Services
{
    public interface ICabinetDataService
    {
        Task<IEnumerable<Cabinet>> GetAllCabinets();
        Task<Cabinet> GetCabinetDetail(Guid cabinetId); 
    }
}
