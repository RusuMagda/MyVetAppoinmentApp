using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
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
        public String Value { get; set; }
        public Guid Gud;
        
        [Parameter]
        public EventCallback<string> ValueChanged { get; set; }
        
        public Shop    shop=new Shop { };

        [Inject]
        public IShopDataService ShopDataService { get; set; } = default!;
        public EventCallback<bool> CloseEventCallback
        {
            get;
            set;
        }
        protected  async Task HandleValidSubmit()
        {
            shop.CabinetId = new Guid(Value);
            ShopDataService.AddShop(shop);
            Close();
           
            
        }

        
        protected async override Task OnInitializedAsync()
        {
            Cabinets = (await CabinetDataService.GetCabinetsWithoutShop()).ToList();
        }
        private Task OnValueChanged(ChangeEventArgs e)
        {
            Value = e.Value.ToString();
            return ValueChanged.InvokeAsync(Value);
        }
        public void Close()
        {
           
            
            
            NavigationManager.NavigateTo("/shops");

        }
    }
}