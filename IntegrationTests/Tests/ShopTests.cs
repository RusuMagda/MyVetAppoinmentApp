using MyVetAppoinment.IntegrationTest;
using Xunit;

namespace IntegrationTests
{
    public class ShopTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private HttpClient HttpClient;

        public ShopTests(CustomWebApplicationFactory<Program> factory)
        {
            HttpClient = factory.CreateClient();
        }


        [Fact]
        public async Task TestGetShopsAsync()
        {
            //Arrange
            var request = "api/Shops";
            // Act
            var response = await HttpClient.GetAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
        }
        [Fact]
        public async Task TestGetShopAsync()
        {
            // Arrange
            var request = "/api/Shops/4af1a2fb-61a2-4059-b3bb-bfad4aa07416";
            // Act
            var response = await HttpClient.GetAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        /*public async Task TestGetShopDrugsAsync()
        {
            // Arrange
            var request = "/api/Shops/4af1a2fb-61a2-4059-b3bb-bfad4aa07416/drugs";
            // Act
            var response = await HttpClient.GetAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
        }*/
        [Fact]

        public async Task TestPostShopAsync()
        {
            // Arrange
            var request = new
            {
                Url = "/api/Shops",
                Body = new
                {
                    ShopId = Guid.NewGuid(),
                    Name = "TestShop",
                    CabinetId = "8a8d5c8c - bb42 - 4ada - ae09 - 8679f1e82a82"

                }
            };

            // Act
            var response = await HttpClient.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var value = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestPutShopAsync()
        {
            // Arrange
            var request = new
            {
                Url = "/api/Shops/4af1a2fb-61a2-4059-b3bb-bfad4aa07416",
                Body = new
                {
                    ShopId = Guid.NewGuid(),
                    Name = "PharmaShop",
                    CabinetId = "8a8d5c8c-bb42-4ada-ae09-8679f1e82a82"
                }
            };

            // Act
            var response = await HttpClient.PutAsync(request.Url, ContentHelper.GetStringContent(request.Body));

            // Assert
            response.EnsureSuccessStatusCode();
        }

    }
