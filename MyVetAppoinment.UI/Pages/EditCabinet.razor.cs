using Microsoft.AspNetCore.Components;
using MyVetAppoinment.Shared.Domain;
using MyVetAppoinment.UI.Pages.Services;
using System.Net.Http.Json;

namespace MyVetAppoinment.UI.Pages
{
    public partial class EditCabinet
    {
        [Inject]
        public ICabinetDataService CabinetDataService { get; set; }

        [Parameter]
        public Guid cabinetId { get; set; }
        protected string Title = "Edit";
        protected Cabinet cabinet = new Cabinet();
        protected override async Task OnParametersSetAsync()
        {
            if (cabinetId != null)
            {

                cabinet = await CabinetDataService.GetCabinetDetail(cabinetId);
            }
        }
        protected async Task SaveCabinet()
        {

            CabinetDataService.EditCabinet(cabinetId,cabinet);
           
            Cancel();
        }
        public void Cancel()
        {
            NavigationManager.NavigateTo("/cabinetsoverview");
        }
    }
}

