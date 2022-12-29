using System.Net;
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
            var request = "/api/v1/Cabinets";
            // Act
            var response = await HttpClient.GetAsync(request);

            // Assert
            Assert.True(response.IsSuccessStatusCode);
        }
        [Fact]
        public async Task TestGetCabinetAsync()
        {
            // Arrange
            var request = "/api/v1/Cabinets/3937a85c-fc53-40d9-b588-2fd95fa86518";
            // Act
            var response = await HttpClient.GetAsync(request);

            // Assert
            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task TestGetNonExistingCabinetAsync()
        {
            // Arrange
            var request = "/api/v1/Cabinets/96ad18b8-8b3b-443c-9a86-2d3fc36b8399";
            // Act
            var response = await HttpClient.GetAsync(request);

            // Assert
            Assert.True(response.StatusCode == HttpStatusCode.NotFound);
        }
        [Fact]
        public async Task TestPostCabinetAsync()
        {
            // Arrange
            var request = new
            {
                Url = "/api/v1/Cabinets",
                Body = new
                {
                    Id = Guid.NewGuid(),
                    Name = "TestVet",
                    Address = "Str. Stefan Cel Mare",
                    PhoneNumber = "0756432567",
                    Description = "cabinet"
                }
            };

            // Act
            var response = await HttpClient.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));

            // Assert
            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task TestGetCabinetClientsAsync()
        {
            // Arrange
            var request = "/api/v1/Cabinets/3937a85c-fc53-40d9-b588-2fd95fa86518/clients";
            // Act
            var response = await HttpClient.GetAsync(request);

            // Assert
            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task TestPutCabinetAsync()
        {
            // Arrange
            var request = new
            {
                Url = "/api/v1/Cabinets/3937a85c-fc53-40d9-b588-2fd95fa86518",
                Body = new
                {
                    Name = "NewVet",
                    Address = "New Address",
                    PhoneNumber = "0756432567",
                    Description = "cabinet"
                }
            };

            // Act
            var response = await HttpClient.PutAsync(request.Url, ContentHelper.GetStringContent(request.Body));

            // Assert
            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task TestDeleteCabinetAsync()
        {
            // Arrange
            var request = "/api/v1/Cabinets/f5c0e1b8-fcf4-4e43-ab72-609eb7c0d6e3";
            // Act
            var response = await HttpClient.DeleteAsync(request);

            // Assert
            Assert.True(response.IsSuccessStatusCode);
        }
    }
}
