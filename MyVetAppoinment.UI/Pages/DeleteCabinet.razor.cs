using Microsoft.AspNetCore.Components;
using MyVetAppoinment.Shared.Domain;
using MyVetAppoinment.UI.Pages.Services;
using System.Net.Http.Json;

namespace MyVetAppoinment.UI.Pages
{
    public partial class DeleteCabinet
    {
        [Inject]
        public ICabinetDataService CabinetDataService { get; set; }

        [Parameter]
        public Guid cabinetId { get; set; }

        Cabinet cabinet = new Cabinet();
        protected override async Task OnInitializedAsync()
        {
            cabinet = await CabinetDataService.GetCabinetDetail(cabinetId);
            //cabinet = await Http.GetFromJsonAsync<Cabinet>("https://localhost:7193/api/Cabinets/" + cabinetId);
        }
        protected async Task RemoveCabinet(Guid cabinetId)
        {
            CabinetDataService.DeleteCabinet(cabinetId);
            Cancel();
        }
        public async Task Cancel()
        {

            await Task.Delay(3000);
            NavigationManager.NavigateTo("/cabinetsoverview");
        }
    }
}

