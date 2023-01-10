using MyVetAppoinment.Shared.Domain;

namespace MyVetAppoinment.UI.Pages.Services
{
    public interface IDrugDataService
    {
        Task<IEnumerable<Drug>?> GetAllDrugs();
        Task<IEnumerable<Drug>?> GetAllDrugsCabinet(Guid cabinetId);
        
        void AddDrug(Drug drug);

        void EditDrug(Guid drugId, Drug drug);
        void DecreaseDrugStock(Guid drugId, int quantity, Drug drug);
        void DeleteDrug(Guid drugId);
    }
}
