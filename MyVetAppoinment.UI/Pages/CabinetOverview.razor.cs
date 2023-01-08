using Microsoft.AspNetCore.Components;
using MyVetAppoinment.Shared.Domain;
using MyVetAppoinment.UI.Pages.Services;

namespace MyVetAppoinment.UI.Pages
{
    public partial class CabinetOverview
    {
        [Inject]
        public ICabinetDataService CabinetDataService { get; set; } = default!;

        [Inject] public IShopDataService ShopDataService { get; set; } = default!;

        public List<Cabinet> Cabinets { get; set; } = default!;
        public List<Shop> Shops { get; set; } = default!;
        protected async override Task OnInitializedAsync()
        {
            var result = await CabinetDataService.GetAllCabinets();
            if (result != null)
            {
                Cabinets = result.ToList();
            }

            var list = await ShopDataService.GetAllShops();
            if (list != null)
            {
                Shops = list.ToList();
            }
        }

    }
}
