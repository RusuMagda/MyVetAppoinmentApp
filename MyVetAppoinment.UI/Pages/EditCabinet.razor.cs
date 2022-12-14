using Microsoft.AspNetCore.Components;
using MyVetAppoinment.Shared.Domain;
using MyVetAppoinment.UI.Pages.Services;

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
            var result = await CabinetDataService.GetCabinetDetail(CabinetId);
            if (result != null)
            {
                cabinet = result;
            }
        }
        protected Task SaveCabinet()
        {
            
            CabinetDataService.EditCabinet(CabinetId,cabinet);
           
            Cancel();
            return Task.CompletedTask;
        }
        public void Cancel()
        {
            NavigationManager.NavigateTo("/cabinetsoverview");
        }
    }
}

