using MyVetAppoinment.Shared.Domain;
using System.Text.Json;

namespace MyVetAppoinment.UI.Pages.Services
{
    public class DrugDataService : IDrugDataService
    {
        private const string ApiURL = "https://localhost:7193/api/Drugs";
        private readonly HttpClient httpClient;

        public DrugDataService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IEnumerable<Drug>> GetAllDrugs()
        {
            return await JsonSerializer
                .DeserializeAsync<IEnumerable<Drug>>
                (await httpClient.GetStreamAsync(ApiURL),
                new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true,
                });
        }

        public async Task<Drug> GetDrugDetail(Guid drugId)
        {
            throw new NotImplementedException();
        }
    }
}
