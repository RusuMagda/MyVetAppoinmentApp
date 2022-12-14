using Microsoft.AspNetCore.Components;
using MyVetAppoinment.Shared.Domain;
using MyVetAppoinment.UI.Pages.Services;

namespace MyVetAppoinment.UI.Pages
{
    public partial class SeeClients
    {
        public List<Cabinet> Cabinets { get; set; } = default!;
        [Inject]
        public ICabinetDataService CabinetDataService { get; set; } = default!;
      
        public EventCallback<string> ValueChanged { get; set; }
        public String Value { get; set; }
        public List<Client> Clients { get; set; } = default!;
        [Parameter]
        public Guid CabinetId { get; set; }
        protected async override Task OnInitializedAsync()
        {
           
            Cabinets = (await CabinetDataService.GetAllCabinets()).ToList();
        }
        private Task OnValueChanged(ChangeEventArgs e)
        {
            Value = e.Value.ToString();
            return ValueChanged.InvokeAsync(Value);
        }
        protected async Task Close()
        {
            Clients = (await CabinetDataService.GetAllClients(new Guid(Value))).ToList();
            


        }
    }
}
