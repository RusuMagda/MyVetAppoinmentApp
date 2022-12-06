
using Microsoft.AspNetCore.Components;
using MyVetAppoinment.Shared.Domain;
using MyVetAppoinment.UI.Pages.Services;

namespace MyVetAppoinment.UI.Pages
{
    public partial class CabinetOverview
    {
        [Inject]
        public ICabinetDataService CabinetDataService { get; set; }

        public List<Cabinet> Cabinets { get; set; } = default!;
        protected async override Task OnInitializedAsync()
        {
            Cabinets = (await CabinetDataService.GetAllCabinets()).ToList();
        }

    }
}
