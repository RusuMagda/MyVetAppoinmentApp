using MyVetAppoinment.Shared.Domain;
using System.Text.Json;

namespace MyVetAppoinment.UI.Pages.Services
{
    public class CabinetDataService : ICabinetDataService
    {
        private const string ApiURL = "https://localhost:7193/api/Cabinets";
        private readonly HttpClient httpClient;

        public CabinetDataService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IEnumerable<Cabinet>> GetAllCabinets()
        {
            return await JsonSerializer
                .DeserializeAsync<IEnumerable<Cabinet>>
                (await httpClient.GetStreamAsync(ApiURL), 
                new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true,
                });
        }

        public async Task<Cabinet> GetCabinetDetail(Guid cabinetId)
        {
            throw new NotImplementedException();
        }
    }
}
