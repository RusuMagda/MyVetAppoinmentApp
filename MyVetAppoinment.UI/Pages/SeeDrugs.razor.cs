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

        public List<Drug> ShoppingList = new List<Drug>();
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

        public async Task AddDrugToList(Drug drug)
        {
            ShoppingList.Add(drug);
        }

        public int GetTotal()
        {
            int total = 0;
            foreach (var drug in ShoppingList)
            {
                total += drug.Price;
            }
            return total;
        }

    }
}
