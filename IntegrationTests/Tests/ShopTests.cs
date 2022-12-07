using Xunit;

namespace IntegrationTests.Tests
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
            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task TestGetShopAsync()
        {
            // Arrange
            var request = "/api/Shops/4af1a2fb-61a2-4059-b3bb-bfad4aa07416";
            // Act
            var response = await HttpClient.GetAsync(request);

            // Assert
            Assert.True(response.IsSuccessStatusCode);
        }

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
                    ShopName = "TestShop",
                    CabinetId = "3937a85c-fc53-40d9-b588-2fd95fa86518"
                }
            };

            // Act
            var response = await HttpClient.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var value = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.True(response.IsSuccessStatusCode);
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
                    ShopName = "PharmaShop",
                    CabinetId = "8a8d5c8c-bb42-4ada-ae09-8679f1e82a82"
                }
            };

            // Act
            var response = await HttpClient.PutAsync(request.Url, ContentHelper.GetStringContent(request.Body));

            // Assert
            Assert.True(response.IsSuccessStatusCode);
        }

    }
}
