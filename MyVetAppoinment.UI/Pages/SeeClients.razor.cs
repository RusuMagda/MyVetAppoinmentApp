using Microsoft.AspNetCore.Components;
using MyVetAppoinment.Shared.Domain;
using MyVetAppoinment.UI.Pages.Services;

namespace MyVetAppoinment.UI.Pages
{
    public partial class SeeClients
    {
        [Inject]
        public ICabinetDataService CabinetDataService { get; set; } = default!;
        public List<Client> Clients { get; set; } = default!;
        [Parameter]
        public Guid CabinetId { get; set; }
        protected async override Task OnInitializedAsync()
        {
            Clients = (await  CabinetDataService.GetAllClients(CabinetId)).ToList();
        }
    }
}
