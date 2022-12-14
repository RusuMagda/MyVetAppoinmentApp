using Microsoft.AspNetCore.Components;
using MyVetAppoinment.Shared.Domain;
using MyVetAppoinment.UI.Pages.Services;

namespace MyVetAppoinment.UI.Pages
{
    public partial class AddShop
    {
        public Guid CabinetId { get; set; }
        public List<Cabinet> Cabinets { get; set; } = default!;
        [Inject]
        public ICabinetDataService CabinetDataService { get; set; } = default!;
        
        [Parameter]
        public String? Value { get; set; }

        [Parameter]
        public EventCallback<string> ValueChanged { get; set; }
        
        private Shop shop = new();
        public Shop? Shop { get; set; }
        

        [Inject]
        public IShopDataService ShopDataService { get; set; } = default!;
        public EventCallback<bool> CloseEventCallback
        {
            get;
            set;
        }
        protected Task HandleValidSubmit()
        {
            if (Value != null)
            {
                shop.CabinetId = new Guid(Value);
                ShopDataService.AddShop(shop);
                Close();
            }

            return Task.CompletedTask;
        }

        
        protected async override Task OnInitializedAsync()
        {
            var result = await CabinetDataService.GetCabinetsWithoutShop();
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
        public void Close()
        {
           
            
            
            NavigationManager.NavigateTo("/shops");

        }
    }
}