
using Microsoft.AspNetCore.Components;
using MyVetAppoinment.Shared.Domain;
using MyVetAppoinment.UI.Pages.Services;

namespace MyVetAppoinment.UI.Pages
{
    public partial class ShopsOverview
    {
        [Inject] public IShopDataService ShopDataService { get; set; } = default!;
        [Inject]
        public ICabinetDataService CabinetDataService { get; set; } = default!;

        public List<Shop> Shops { get; set; } = default!;
        public List<Cabinet> Cabinets { get; set; } = default!;

        protected async override Task OnInitializedAsync()
        {
            var result = await ShopDataService.GetAllShops();
            var CabinetsList = await CabinetDataService.GetAllCabinets();
            if (result != null)
            {
                Shops = result.ToList();
            }

            if (CabinetsList != null)
            {
                Cabinets = CabinetsList.ToList();
            }
        }

    }
}
