using Microsoft.AspNetCore.Components;
using MyVetAppoinment.Shared.Domain;
using MyVetAppoinment.UI.Pages.Services;

namespace MyVetAppoinment.UI.Pages
{
    public partial class Registration
    {
        [Parameter]
        public Guid CabinetId { get; set; }
        [Inject] public ICabinetDataService CabinetDataService { get; set; } = default!;
        [Inject] public IClientDataService ClientDataService { get; set; } = default!;

        private Client client = new();
        public Client? Client
        {
            get;
            set;
        }


        protected string Title = "Add";


        protected async Task SaveClient()
        {
            
            var cli =  ClientDataService.GetClientEmail(client.EMail);
            await Task.Delay(2000);
            Console.WriteLine(cli.GetType());
            if (cli.GetType().ToString() == "MyVetAppoinment.Shared.Domain.Client")
            {
                var cl = await ClientDataService.GetClientEmail(client.EMail);
                Console.WriteLine(client.Name);
                Console.WriteLine(cl.Name);
                if(cl.Name==client.Name && cl.PhoneNumber==client.PhoneNumber)
                    NavigationManager.NavigateTo("/addpet/" + cli.Id + "/" + CabinetId);
                else
                    NavigationManager.NavigateTo("/");

            }
            else
            {
                
                ClientDataService.AddClient(client);
                await Task.Delay(2000);

              
                var cl = await ClientDataService.GetClientEmail(client.EMail);
                if (cl.Name == client.Name && cl.PhoneNumber == client.PhoneNumber)
                    NavigationManager.NavigateTo("/addpet/" + cl.Id + "/" + CabinetId);
                else
                {

                    NavigationManager.NavigateTo("/");
                }
            }










        }
        public async Task Cancel()
        {
            await Task.Delay(1000);
            NavigationManager.NavigateTo("/");
        }
    }
}


