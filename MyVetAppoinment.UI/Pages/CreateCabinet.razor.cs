using Microsoft.AspNetCore.Components;
using MyVetAppoinment.Shared.Domain;
using MyVetAppoinment.UI.Pages.Services;

namespace MyVetAppoinment.UI.Pages
{
    public partial class CreateCabinet
    {
        [Inject] public ICabinetDataService CabinetDataService { get; set; } = default!;

        private Cabinet cabinet = new();
        public Cabinet? Cabinet
        {
            get;
            set;
        }
      

        protected string Title = "Add";
       
       
        protected async Task SaveCabinet()
        {
            CabinetDataService.AddCabinet(cabinet);       
            await Cancel();
        }
        public async Task Cancel()
        {
            await Task.Delay(1000);
            NavigationManager.NavigateTo("/");
        }
    }
}


