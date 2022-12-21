using MyVetAppoinment.Shared.Domain;
using System.Net.Http.Json;
using System.Text.Json;

namespace MyVetAppoinment.UI.Pages.Services
{
    public class ClientDataService : IClientDataService
    {

        private const string ApiUrl = "api/Clients/";
        private readonly HttpClient httpClient;

        public ClientDataService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Client>?> GetAllClients()
        {
            return await JsonSerializer
                 .DeserializeAsync<IEnumerable<Client>>
                 (await httpClient.GetStreamAsync($"https://localhost:7193/{ApiUrl}"),
                 new JsonSerializerOptions()
                 {
                     PropertyNameCaseInsensitive = true,
                 });

        }

        public async Task<Client?> GetClientDetail(Guid clientId)
        {
            return await httpClient.GetFromJsonAsync<Client>($"https://localhost:7193/{ApiUrl}" + clientId);
        }
        
        public async Task<Client?> GetClientEmail(String email)
        {
            Console.WriteLine(email);
            Console.WriteLine("UUUUUUUUUUUu");
            var cli= await httpClient.GetFromJsonAsync<Client>($"https://localhost:7193/{ApiUrl}" + email);
            
           
            return cli;
            
          
        }

        public async void AddClient (Client  client)
        {

            await httpClient.PostAsJsonAsync($"https://localhost:7193/{ApiUrl}", client);


        }
        public async void EditClient(Guid clientId, Client client)
        {

            await httpClient.PutAsJsonAsync($"https://localhost:7193/{ApiUrl}" + clientId, client);


        }

        public async void DeleteClient(Guid clientId)
        {
            await httpClient.DeleteAsync($"https://localhost:7193/{ApiUrl}" + clientId);
        }
    }
}
