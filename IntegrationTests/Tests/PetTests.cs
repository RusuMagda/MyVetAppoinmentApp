using Xunit;

namespace IntegrationTests.Tests
{
    public class PetTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private HttpClient HttpClient;

        public PetTests(CustomWebApplicationFactory<Program> factory)
        {
            HttpClient = factory.CreateClient();
        }

        [Fact]
        public async Task TestGetPetsAsync()
        {
            // Arrange
            var request = "/api/Pets";
            // Act
            var response = await HttpClient.GetAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestGetPetAsync()
        {
            // Arrange
            var request = "/api/Pets/7febb009-3dc4-4413-a5c4-4142b101be37";
            // Act
            var response = await HttpClient.GetAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestGetPetAppointmnentsAsync()
        {
            // Arrange
            var request = "/api/Pets/7febb009-3dc4-4413-a5c4-4142b101be37/appointments";
            // Act
            var response = await HttpClient.GetAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestPostPetAsync()
        {
            // Arrange
            var request = new
            {
                Url = "/api/Pets",
                Body = new
                {
                    Id = Guid.NewGuid(),
                    OwnerId = "3837a85c-fc53-40d9-b588-2fd95fa86518",
                    Name = "Kara",
                    Birthdate = "2022-12-06T16:47:02.959Z"
                }
            };

            // Act
            var response = await HttpClient.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var value = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestPutPetAsync()
        {
            // Arrange
            var request = new
            {
                Url = "/api/Pets/7febb009-3dc4-4413-a5c4-4142b101be37",
                Body = new
                {
                    OwnerId = "427a80d3-09b2-4c92-8e4c-369b8de6fe26",
                    Name = "Kara",
                    Birthdate = "2022-12-06T16:47:02.959Z"
                }
            };

            // Act
            var response = await HttpClient.PutAsync(request.Url, ContentHelper.GetStringContent(request.Body));

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}
