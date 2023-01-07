using Microsoft.AspNetCore.Components;
using MyVetAppoinment.Shared.Domain;
using MyVetAppoinment.UI.Pages.Services;

namespace MyVetAppoinment.UI.Pages
{
    public partial class SeeDrugs
    {
        [Parameter]
        public Guid CabinetId { get; set; }
        public List<Drug> Drugs { get; set; } = default!;
        [Inject] public ICabinetDataService CabinetDataService { get; set; } = default!;
        [Inject] public IDrugDataService DrugDataService { get; set; } = default!;

        private Drug drug = new();
        public Drug? Drug

        {
            get;
            set;
        }
        protected async override Task OnInitializedAsync()
        {
            var result = await DrugDataService.GetAllDrugsCabinet(CabinetId);
            if (result != null)
            {
                Drugs = result.ToList();
            }
        }

    }
}
