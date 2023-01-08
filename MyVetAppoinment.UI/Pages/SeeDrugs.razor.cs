using Microsoft.AspNetCore.Components;
using MyVetAppoinment.Shared.Domain;
using MyVetAppoinment.UI.Pages.Services;

namespace MyVetAppoinment.UI.Pages
{
    public partial class SeeDrugs
    {
        [Parameter]
        public Guid ShopId { get; set; }
        public List<Drug> Drugs { get; set; } = default!;
        [Inject] public IShopDataService ShopDataService { get; set; } = default!;
        [Inject] public IDrugDataService DrugDataService { get; set; } = default!;

        protected async override Task OnInitializedAsync()
        {
            var result = await ShopDataService.GetShopDrugs(ShopId);
            if (result != null)
            {
                Drugs = result.ToList();
            }
        }

    }
}
