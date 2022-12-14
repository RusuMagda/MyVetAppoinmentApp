using Microsoft.AspNetCore.Components;
using MyVetAppoinment.Shared.Domain;
using MyVetAppoinment.UI.Pages.Services;

namespace MyVetAppoinment.UI.Pages
{
    public partial class DeleteCabinet
    {
        [Inject] public ICabinetDataService CabinetDataService { get; set; } = default!;

        [Parameter]
        public Guid CabinetId { get; set; }

        Cabinet cabinet = new Cabinet();
        protected override async Task OnInitializedAsync()
        {
            var result = await CabinetDataService.GetCabinetDetail(CabinetId);
            if (result != null)
            {
                cabinet = result;
            }
            
        }
        protected async Task RemoveCabinet(Guid cabinetId)
        {
            CabinetDataService.DeleteCabinet(cabinetId);
            await Cancel();
        }
        public async Task Cancel()
        {
            await Task.Delay(3000);
            NavigationManager.NavigateTo("/cabinetsoverview");
        }
    }
}

