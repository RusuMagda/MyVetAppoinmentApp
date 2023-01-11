using Microsoft.AspNetCore.Components;
using MyVetAppoinment.Shared.Domain;
using MyVetAppoinment.UI.Pages.Services;

namespace MyVetAppoinment.UI.Pages
{
    public partial class SeeDrugs
    {
        [Parameter]
        public Guid ShopId { get; set; }
        public List<Drug> Drugs { get; set; } = default!;

        public Dictionary<Drug, int> ShoppingList = new Dictionary<Drug, int>();

        public string PageScope = "Shop";

        [Parameter]
        public int Value { get; set; }

        [Parameter]
        public EventCallback<int> ValueChanged { get; set; }

        public Payment Payment = new Payment();
        [Inject] public IShopDataService ShopDataService { get; set; } = default!;
        [Inject] public IDrugDataService DrugDataService { get; set; } = default!;

        protected async override Task OnInitializedAsync()
        {
            var result = await ShopDataService.GetShopDrugs(ShopId);
            if (result != null)
            {
                Drugs = result.ToList();
            }
        }

        public Task AddDrugToList(Drug drug)
        {
            if (ShoppingList.ContainsKey(drug))
            {
                ShoppingList[drug] += 1;
            }
            else
            {
                ShoppingList.Add(drug, 1);
            }

            return Task.CompletedTask;
        }

        public Task RemoveDrugFromList(Drug drug)
        {
            ShoppingList[drug] -= 1;
            if (ShoppingList[drug] == 0)
            {
                ShoppingList.Remove(drug);
            }

            return Task.CompletedTask;
        }

        public int GetTotal()
        {
            int total = 0;
            foreach (var drug in ShoppingList.Keys)
            {
                total += (drug.Price * ShoppingList[drug]);
            }
            return total;
        }

        public Task ShowPaymentForm()
        {
            PageScope = "Payment";
            NavigationManager.NavigateTo("/payment");
            return Task.CompletedTask;
        }

        public void CancelPayment()
        {
            Payment = new Payment();
            PageScope = "Shop";
            NavigationManager.NavigateTo("/seedrugs/" + ShopId);
        }

        public Task MakePayment()
        {
            foreach (var drug in ShoppingList.Keys)
            {
                DrugDataService.DecreaseDrugStock(drug.ID, ShoppingList[drug], drug);
            }
            
            PageScope = "Bill";

            NavigationManager.NavigateTo("/bill");
            return Task.CompletedTask;
        }

        private Task OnValueChanged(ChangeEventArgs e)
        {
            var result = e.Value;
            return ValueChanged.InvokeAsync(Value);
        }
    }
}
