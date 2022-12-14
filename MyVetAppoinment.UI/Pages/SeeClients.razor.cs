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
        public String? Value { get; set; }
        public List<Client> Clients { get; set; } = default!;
        [Parameter]
        public Guid CabinetId { get; set; }
        protected async override Task OnInitializedAsync()
        {
            var result = await CabinetDataService.GetAllCabinets();
            if (result != null)
            {
                Cabinets = result.ToList();
            }
        }
        private Task OnValueChanged(ChangeEventArgs e)
        {
            var result = e.Value;
            if (result != null)
            {
                Value = result.ToString();
            }
            return ValueChanged.InvokeAsync(Value);
        }
        protected async Task Close()
        {
            if (Value != null)
            {
                var result = await CabinetDataService.GetAllClients(new Guid(Value));
                if (result != null)
                {
                    Clients = result.ToList();
                }
            }
            
            
            


        }
    }
}
