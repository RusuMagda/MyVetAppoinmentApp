using Microsoft.AspNetCore.Components;
using MyVetAppoinment.Shared.Domain;
using MyVetAppoinment.UI.Pages.Services;

namespace MyVetAppoinment.UI.Pages
{
    public partial  class DeleteShop
    {
        [Inject] public IShopDataService ShopDataService { get; set; } = default!;

        [Parameter]
        public Guid ShopId { get; set; }

        Shop shop = new Shop();
        protected override async Task OnInitializedAsync()
        {
            var result = await ShopDataService.GetShopDetail(ShopId);
            if (result != null)
            {
                shop = result;
            }

        }
        protected async Task RemoveShop(Guid shopId)
        {
            ShopDataService.DeleteShop(shopId);
            
            await Cancel();
        }
        public async Task Cancel()
        {

            await Task.Delay(3000);
            NavigationManager.NavigateTo("/shopsoverview");
        }
    }
}
