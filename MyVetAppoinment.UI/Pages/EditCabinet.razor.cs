using Microsoft.AspNetCore.Components;
using MyVetAppoinment.Shared.Domain;
using MyVetAppoinment.UI.Pages.Services;
using System.Net.Http.Json;

namespace MyVetAppoinment.UI.Pages
{
    public partial class EditCabinet
    {
        [Inject] public ICabinetDataService CabinetDataService { get; set; } = default!;

        [Parameter]
        public Guid CabinetId { get; set; }
        protected string Title = "Edit";
        protected Cabinet cabinet = new Cabinet();
        protected override async Task OnParametersSetAsync()
        {
            cabinet = await CabinetDataService.GetCabinetDetail(CabinetId);
        }
        protected async Task SaveCabinet()
        {

            CabinetDataService.EditCabinet(CabinetId,cabinet);
           
            Cancel();
        }
        public void Cancel()
        {
            NavigationManager.NavigateTo("/cabinetsoverview");
        }
    }
}

