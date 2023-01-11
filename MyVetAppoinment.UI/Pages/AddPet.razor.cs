using Microsoft.AspNetCore.Components;
using MyVetAppoinment.Shared.Domain;
using MyVetAppoinment.UI.Pages.Services;

namespace MyVetAppoinment.UI.Pages
{
    public partial class AddPet
    {
        [Parameter]
        public Guid ClientId { get; set; }
        [Parameter]
        public Guid CabinetId { get; set; }
        public List<Pet> Pets { get; set; } = default!;
        [Inject]
        public IPetDataService PetDataService { get; set; } = default!;

        [Parameter]
        public String? Value { get; set; }

        [Parameter]
        public String? year { get; set; }
        [Parameter]
        public String? month { get; set; }
        [Parameter]
        public String? day { get; set; }


        public EventCallback<string> ValueChanged { get; set; }

        private Pet pet = new();
        public Pet? Pet { get; set; }
        private Guid petId = Guid.Empty;


        
        protected async Task SavePet()
        {
            if (Value == null)
            {
                
                DateTime date1 = new DateTime(Int32.Parse(year!), Int32.Parse(month!), Int32.Parse(day!), 0, 0, 0, DateTimeKind.Utc);
                pet.OwnerId = ClientId;
                pet.Birthdate = Convert.ToDateTime(date1);
                PetDataService.AddPet(pet);
                await Task.Delay(2000);
               
                var pet1 = await PetDataService.GetPetId(ClientId,pet.Name);

                if (pet1 != null) NavigationManager.NavigateTo("/addappointment/" + pet1.Id + "/" + CabinetId);
            }
            else
            {
                petId = new Guid(Value);
               
                NavigationManager.NavigateTo("/addappointment/" + petId + "/" + CabinetId);
            }
        }
        protected async override Task OnInitializedAsync()
        {
            var result = await PetDataService.GetPetsClient(ClientId);
            if (result != null)
            {
                Pets = result.ToList();
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
        public async Task Cancel()
        {
            await Task.Delay(1000);
            NavigationManager.NavigateTo("/");
        }
    }
}
