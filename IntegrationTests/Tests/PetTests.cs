using System.Net;
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
            var request = "/api/v1/Pets";
            // Act
            var response = await HttpClient.GetAsync(request);

            // Assert
            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task TestGetPetAsync()
        {
            // Arrange
            var request = "/api/v1/Pets/7febb009-3dc4-4413-a5c4-4142b101be37";
            // Act
            var response = await HttpClient.GetAsync(request);

            // Assert
            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task TestGetPetByNonExistingId()
        {
            // Arrange
            var request = "/api/v1/Pets/d66e1337-ff2d-457b-b47a-abd47f4340b5";
            // Act
            var response = await HttpClient.GetAsync(request);

            // Assert
            Assert.True(response.StatusCode == HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task TestGetPetAppointmentsAsync()
        {
            // Arrange
            var request = "/api/v1/Pets/7febb009-3dc4-4413-a5c4-4142b101be37/appointments";
            // Act
            var response = await HttpClient.GetAsync(request);

            // Assert
            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task TestPostPetAsync()
        {
            // Arrange
            var request = new
            {
                Url = "/api/v1/Pets",
                Body = new
                {
                    Id = Guid.NewGuid(),
                    OwnerId = "3837a85c-fc53-40d9-b588-2fd95fa86518",
                    Name = "Kara",
                    Birthdate = "2021-12-06T16:47:02.959Z"
                }
            };

            // Act
            var response = await HttpClient.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));

            // Assert
            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task TestPutPetAsync()
        {
            // Arrange
            var request = new
            {
                Url = "/api/v1/Pets/7febb009-3dc4-4413-a5c4-4142b101be37",
                Body = new
                {
                    Id = "7febb009-3dc4-4413-a5c4-4142b101be37",
                    OwnerId = "427a80d3-09b2-4c92-8e4c-369b8de6fe26",
                    Name = "UpdateDog",
                    Birthdate = "2020-12-06T16:47:02.959Z"
                }
            };

            // Act
            var response = await HttpClient.PutAsync(request.Url, ContentHelper.GetStringContent(request.Body));

            // Assert
            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task TestDeletePetAsync()
        {
            // Arrange
            var request = "/api/v1/Pets/e1c0bbc0-045f-4908-93f8-773f14732508";
            // Act
            var response = await HttpClient.DeleteAsync(request);

            // Assert
            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task TestGetPetIdAsync()
        {
            // Arrange
            var request = "/api/v1/Pets/3837a85c-fc53-40d9-b588-2fd95fa86518/oana";

            // Act
            var response = await HttpClient.GetAsync(request);

            //Assert
            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task TestGetPetsClientAsync()
        {
            // Arrange
            var request = "/api/v1/Pets/3837a85c-fc53-40d9-b588-2fd95fa86518/pets";

            // Act
            var response = await HttpClient.GetAsync(request);

            //Assert
            Assert.True(response.IsSuccessStatusCode);
        }
    }
}
