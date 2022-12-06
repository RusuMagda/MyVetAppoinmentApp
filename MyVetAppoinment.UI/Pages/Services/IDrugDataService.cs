using MyVetAppoinment.Shared.Domain;

namespace MyVetAppoinment.UI.Pages.Services
{
    public interface IDrugDataService
    {
        Task<IEnumerable<Drug>> GetAllDrugs();
        Task<Drug> GetDrugDetail(Guid drugId);
    }
}
