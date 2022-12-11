using Microsoft.AspNetCore.Components;
using MyVetAppoinment.Shared.Domain;
using MyVetAppoinment.UI.Pages.Services;
using System.Net.Http.Json;

namespace MyVetAppoinment.UI.Pages
{
    public partial class CreateCabinet
    {
        [Inject] public ICabinetDataService CabinetDataService { get; set; } = default!;

        public Cabinet cabinet=new Cabinet();
      

        protected string Title = "Add";
       
       
        protected async Task SaveCabinet()
        {
            CabinetDataService.AddCabinet(cabinet);       
            Cancel();
        }
        public async Task Cancel()
        {
            await Task.Delay(1000);
            NavigationManager.NavigateTo("/");
        }
    }
}


