using Microsoft.AspNetCore.Components;
using MyVetAppoinment.Shared.Domain;
using MyVetAppoinment.UI.Pages.Services;

namespace MyVetAppoinment.UI.Pages
{
    public partial class EditShop
    {
        [Inject] public IShopDataService ShopDataService { get; set; } = default!;

        [Parameter]
        public Guid ShopId { get; set; }
        protected string Title = "Edit";
        protected Shop shop = new();
        protected override async Task OnParametersSetAsync()
        {
            shop = await ShopDataService.GetShopDetail(ShopId);
        }
        protected async Task SaveShop()
        {

            ShopDataService.EditShop(ShopId, shop);

            Cancel();
        }
        public async Task Cancel()
        {
            await Task.Delay(2000);
            NavigationManager.NavigateTo("/shopsoverview");
        }
    }
}
