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

        public bool PayButtonPressed = false;

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

        public async Task AddDrugToList(Drug drug)
        {
            if (ShoppingList.ContainsKey(drug))
            {
                ShoppingList[drug] += 1;
            }
            else
            {
                ShoppingList.Add(drug, 1);
            }
        }

        public async Task RemoveDrugFromList(Drug drug)
        {
            ShoppingList[drug] -= 1;
            if (ShoppingList[drug] == 0)
            {
                ShoppingList.Remove(drug);
            }
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

        public void ShowPaymentForm()
        {
            PayButtonPressed = true;
        }

        public void CancelPayment()
        {
            PayButtonPressed = false;
            Payment = new Payment();
        }

        public async Task MakePayment()
        {
            foreach (var drug in ShoppingList.Keys)
            {
                DrugDataService.DecreaseDrugStock(drug.ID, ShoppingList[drug], drug);
            }

            PayButtonPressed = false;
            //ShoppingList = new Dictionary<Drug, int>();
            PageScope = "Message";

            NavigationManager.NavigateTo("/successfulpayment");
        }

        private Task OnValueChanged(ChangeEventArgs e)
        {
            var result = e.Value;
            return ValueChanged.InvokeAsync(Value);
        }

        public void ViewBill()
        {
            PageScope = "Bill";
            NavigationManager.NavigateTo("/bill");
		}

    }
}
