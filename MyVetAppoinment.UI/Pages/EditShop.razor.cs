using Microsoft.AspNetCore.Components;
using MyVetAppoinment.Shared.Domain;
using MyVetAppoinment.UI.Pages.Services;

namespace MyVetAppoinment.UI.Pages
{
    public partial class EditShop
    {
        [Inject]
        public IShopDataService ShopDataService { get; set; }

        [Parameter]
        public Guid shopId { get; set; }
        protected string Title = "Edit";
        protected Shop shop = new Shop();
        protected override async Task OnParametersSetAsync()
        {
            if (shopId != null)
            {

                shop = await ShopDataService.GetShopDetail(shopId);
            }
        }
        protected async Task SaveShop()
        {

            ShopDataService.EditShop(shopId, shop);

            Cancel();
        }
        public async Task Cancel()
        {
            await Task.Delay(2000);
            NavigationManager.NavigateTo("/shopsoverview");
        }
    }
}
