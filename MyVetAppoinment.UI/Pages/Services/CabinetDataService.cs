using MyVetAppoinment.Shared.Domain;
using System.Net.Http.Json;
using System.Text.Json;

namespace MyVetAppoinment.UI.Pages.Services
{
    public class CabinetDataService : ICabinetDataService
    {
        private const string ApiUrl = "api/Cabinets/";
        private readonly HttpClient httpClient;

        public CabinetDataService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IEnumerable<Cabinet>?> GetAllCabinets()
        {
            return await JsonSerializer
                .DeserializeAsync<IEnumerable<Cabinet>>
                (await httpClient.GetStreamAsync($"https://localhost:7193/{ApiUrl}"), 
                new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true,
                });
        }
        public async Task<IEnumerable<Cabinet>?> GetCabinetsWithoutShop()
        {
            return await JsonSerializer
                .DeserializeAsync<IEnumerable<Cabinet>>
                (await httpClient.GetStreamAsync($"https://localhost:7193/{ApiUrl}" + "shop"),
                new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true,
                });
        }
        public async Task<IEnumerable<Client>?> GetAllClients(Guid cabinetId)
        {
            return await JsonSerializer
                .DeserializeAsync<IEnumerable<Client>>
                (await httpClient.GetStreamAsync($"https://localhost:7193/{ApiUrl}" + cabinetId+"/clients"),
                new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true,
                });
        }

        public async Task<Cabinet?> GetCabinetDetail(Guid cabinetId)
        {
            return await httpClient.GetFromJsonAsync<Cabinet>($"https://localhost:7193/{ApiUrl}" + cabinetId);
        }
        public async void AddCabinet(Cabinet cabinet)
        {
            
                await httpClient.PostAsJsonAsync($"https://localhost:7193/{ApiUrl}", cabinet);

            
        }
        public async void EditCabinet(Guid cabinetId, Cabinet cabinet)
        {

            await httpClient.PutAsJsonAsync($"https://localhost:7193/{ApiUrl}" + cabinetId, cabinet);


        }
        public async void DeleteCabinet(Guid cabinetId)
        {
            await httpClient.DeleteAsync($"https://localhost:7193/{ApiUrl}" + cabinetId);
        }
    }
}
