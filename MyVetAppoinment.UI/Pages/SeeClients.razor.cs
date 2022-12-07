using Microsoft.AspNetCore.Components;
using MyVetAppoinment.Shared.Domain;
using MyVetAppoinment.UI.Pages.Services;

namespace MyVetAppoinment.UI.Pages
{
    public partial class SeeClients
    {
        [Inject]
        public ICabinetDataService CabinetDataService { get; set; }
        public List<Client> Clients { get; set; } = default!;
        [Parameter]
        public Guid cabinetId { get; set; }
        protected async override Task OnInitializedAsync()
        {
            Clients = (await  CabinetDataService.GetAllClients(cabinetId)).ToList();
        }
    }
}
