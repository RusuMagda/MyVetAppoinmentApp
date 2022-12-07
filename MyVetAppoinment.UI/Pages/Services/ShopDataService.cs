using MyVetAppoinment.Shared.Domain;
using System.Net.Http.Json;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace MyVetAppoinment.UI.Pages.Services
{
    public class ShopDataService : IShopDataService
    {
      
            private const string ApiURL = "https://localhost:7193/api/shops/";
            private readonly HttpClient httpClient;

            public ShopDataService(HttpClient httpClient)
            {
                this.httpClient = httpClient;
            }
       
        public async Task<IEnumerable<Shop>> GetAllShops()
            {
            return await JsonSerializer
                 .DeserializeAsync<IEnumerable<Shop>>
                 (await httpClient.GetStreamAsync(ApiURL),
                 new JsonSerializerOptions()
                 {
                     PropertyNameCaseInsensitive = true,
                 });
        
    }

        public async Task<Shop> GetShopDetail(Guid shopId)
        {
            return await httpClient.GetFromJsonAsync<Shop>(ApiURL + shopId);
        }
    }
}
