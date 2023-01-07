using MyVetAppoinment.Shared.Domain;
using System.Net.Http.Json;
using System.Text.Json;

namespace MyVetAppoinment.UI.Pages.Services
{

    public class DrugDataService : IDrugDataService
    {

        private const string ApiUrl = "api/v1/drugs/";
        private readonly HttpClient httpClient;

        public DrugDataService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IEnumerable<Drug>?> GetAllDrugs()
        {
            return await JsonSerializer
                 .DeserializeAsync<IEnumerable<Drug>>
                 (await httpClient.GetStreamAsync($"https://localhost:7193/{ApiUrl}"),
                 new JsonSerializerOptions()
                 {
                     PropertyNameCaseInsensitive = true,
                 });

        }
        public async Task<IEnumerable<Drug>?> GetAllDrugsCabinet(Guid cabinetId)
        {
            return await JsonSerializer
                .DeserializeAsync<IEnumerable<Drug>>
                (await httpClient.GetStreamAsync($"https://localhost:7193/{ApiUrl}" + cabinetId + "/drugs"),
                new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true,
                });
        }
        public async void AddDrug(Drug drug)
        {

            await httpClient.PostAsJsonAsync($"https://localhost:7193/{ApiUrl}", drug);


        }
        public async void EditDrug(Guid drugId, Drug drug)
        {

            await httpClient.PutAsJsonAsync($"https://localhost:7193/{ApiUrl}" + drugId, drug);


        }

        public async void DeleteDrug(Guid drugId)
        {
            await httpClient.DeleteAsync($"https://localhost:7193/{ApiUrl}" + drugId);
        }

      
    }
}
