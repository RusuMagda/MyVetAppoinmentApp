using IntegrationTests.Configure;
using Xunit;

namespace IntegrationTests.Tests
{
    public class ClientTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private HttpClient HttpClient;

        public ClientTests(CustomWebApplicationFactory<Program> factory)
        {
            HttpClient = factory.CreateClient();
        }

        [Fact]
        public async Task TestGetClientsAsync()
        {
            // Arrange
            var request = "/api/Clients";
            // Act
            var response = await HttpClient.GetAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestGetClientAsync()
        {
            // Arrange
            var request = "/api/Clients/3837a85c-fc53-40d9-b588-2fd95fa86518";
            // Act
            var response = await HttpClient.GetAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestGetClientPetsAsync()
        {
            // Arrange
            var request = "/api/Clients/3837a85c-fc53-40d9-b588-2fd95fa86518/pets";
            // Act
            var response = await HttpClient.GetAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestPostClientAsync()
        {
            // Arrange
            var request = new
            {
                Url = "/api/Clients",
                Body = new
                {
                    Id = Guid.NewGuid(),
                    Name = "testuser",
                    EMail = "test@yahoo.com",
                    PhoneNumber = "0123456789"
                }
            };

            // Act
            var response = await HttpClient.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var value = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestPutClientAsync()
        {
            // Arrange
            var request = new
            {
                Url = "/api/Clients/3837a85c-fc53-40d9-b588-2fd95fa86518",
                Body = new
                {
                    Name = "oana",
                    EMail = "oanamocanu@yahoo.com",
                    PhoneNumber = "0123456789"
                }
            };

            // Act
            var response = await HttpClient.PutAsync(request.Url, ContentHelper.GetStringContent(request.Body));

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }

}
