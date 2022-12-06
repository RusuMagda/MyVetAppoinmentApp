
using Microsoft.AspNetCore.Components;
using MyVetAppoinment.Shared.Domain;
using MyVetAppoinment.UI.Pages.Services;

namespace MyVetAppoinment.UI.Pages
{
    public partial class DrugOverview
    {
        [Inject]
        public IDrugDataService DrugDataService { get; set; }

        public List<Drug> Drugs { get; set; } = default!;
        protected async override Task OnInitializedAsync()
        {
            Drugs = (await DrugDataService.GetAllDrugs()).ToList();
        }

    }
}
