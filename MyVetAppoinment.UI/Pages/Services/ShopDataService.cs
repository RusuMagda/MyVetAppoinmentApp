using MyVetAppoinment.Shared.Domain;
using System.Net.Http.Json;
using System.Text.Json;

namespace MyVetAppoinment.UI.Pages.Services
{
    public class ShopDataService : IShopDataService
    {
      
            private const string ApiUrl = "api/shops/";
            private readonly HttpClient httpClient;

            public ShopDataService(HttpClient httpClient)
            {
                this.httpClient = httpClient;
            }
       
        public async Task<IEnumerable<Shop>?> GetAllShops()
            {
            return await JsonSerializer
                 .DeserializeAsync<IEnumerable<Shop>>
                 (await httpClient.GetStreamAsync($"https://localhost:7193/{ApiUrl}"),
                 new JsonSerializerOptions()
                 {
                     PropertyNameCaseInsensitive = true,
                 });
        
    }

        public async Task<Shop?> GetShopDetail(Guid shopId)
        {
            return await httpClient.GetFromJsonAsync<Shop>($"https://localhost:7193/{ApiUrl}" + shopId);
        }

        public async void AddShop(Shop shop)
        {

            await httpClient.PostAsJsonAsync($"https://localhost:7193/{ApiUrl}", shop);


        }
        public async void EditShop(Guid shopId, Shop shop)
        {

            await httpClient.PutAsJsonAsync($"https://localhost:7193/{ApiUrl}" + shopId, shop);


        }

        public async void DeleteShop(Guid shopId)
        {
            await httpClient.DeleteAsync($"https://localhost:7193/{ApiUrl}" + shopId);
        }
    }
}
