using Xunit;

namespace IntegrationTests.Tests
{
    public class CabinetTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private HttpClient HttpClient;

        public CabinetTests(CustomWebApplicationFactory<Program> factory)
        {
            HttpClient = factory.CreateClient();
        }

        [Fact]
        public async Task TestGetCabinetsAsync()
        {
            // Arrange
            var request = "/api/Cabinets";
            // Act
            var response = await HttpClient.GetAsync(request);

            // Assert
            Assert.True(response.IsSuccessStatusCode);
        }
        [Fact]
        public async Task TestGetCabinetAsync()
        {
            // Arrange
            var request = "/api/Cabinets/3937a85c-fc53-40d9-b588-2fd95fa86518";
            // Act
            var response = await HttpClient.GetAsync(request);

            // Assert
            Assert.True(response.IsSuccessStatusCode);
        }
        [Fact]
        public async Task TestPostCabinetAsync()
        {
            // Arrange
            var request = new
            {
                Url = "/api/Cabinets",
                Body = new
                {
                    Id = Guid.NewGuid(),
                    Name = "TestVet",
                    Address = "Str. Stefan Cel Mare"

                }
            };

            // Act
            var response = await HttpClient.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var value = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task TestGetCabinetClientsAsync()
        {
            // Arrange
            var request = "/api/Cabinets/3937a85c-fc53-40d9-b588-2fd95fa86518/clients";
            // Act
            var response = await HttpClient.GetAsync(request);

            // Assert
            Assert.True(response.IsSuccessStatusCode);
        }
    }
}
