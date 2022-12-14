
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
        protected List<Cabinet> userList = default!;
        protected Cabinet cabinet = default!;
        protected String cabinetName = string.Empty;
       
        protected async override Task OnInitializedAsync()
        {
            var result = await ShopDataService.GetAllShops();
            if (result != null)
            {
                Shops = result.ToList();
            }
           
            foreach (var shop in Shops)
            {
                var MyShop = await CabinetDataService.GetCabinetDetail(shop.CabinetId);
                if (MyShop != null)
                {
                    cabinet = MyShop;
                }
            }
           
        }

    }
}
