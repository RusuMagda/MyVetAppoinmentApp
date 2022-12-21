using System.Net;
using Xunit;

namespace IntegrationTests.Tests
{
    public class AppointmentTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private HttpClient HttpClient;
        public AppointmentTests(CustomWebApplicationFactory<Program> factory)
        {
            HttpClient = factory.CreateClient();
        }

        [Fact]
        public async Task TestGetAppointmentsAsync()
        {
            // Arrange
            var request = "/api/Appointments";
            // Act
            var response = await HttpClient.GetAsync(request);

            // Assert
            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task TestGetAppointmentAsync()
        {
            // Arrange
            var request = "/api/Appointments/6fa878bc-5a6c-4f6d-804c-2f487b892145";
            // Act
            var response = await HttpClient.GetAsync(request);

            // Assert
            Assert.True(response.IsSuccessStatusCode);
        }

        //[Fact]
        //public async Task TestGetNonExistingAppointmentAsync()
        //{
        //    // Arrange
        //    var request = "/api/Appointments/96ad18b8-8b3b-443c-9a86-2d3fc36b8388";
        //    // Act
        //    var response = await HttpClient.GetAsync(request);

        //    // Assert
        //    Assert.True(response.StatusCode == HttpStatusCode.NotFound);
        //}

        [Fact]
        public async Task TestDeleteAppointmentAsync()
        {
            // Arrange
            var request = "/api/Appointments/659a141f-03ba-4ee8-9faf-944944a85da8";
            // Act
            var response = await HttpClient.DeleteAsync(request);

            // Assert
            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task TestPostAppointmentAsync()
        {
            // Arrange
            var request = new
            {
                Url = "/api/Appointments/7febb009-3dc4-4413-a5c4-4142b101be37/3937a85c-fc53-40d9-b588-2fd95fa86518",
                Body = new
                {
                    Id = Guid.NewGuid(),
                    StartTime = "2023-12-06T16:47:02.959Z",
                    EndTime = "2023-12-06T17:47:02.959Z",
                    Description = "description"
                }
            };

            // Act
            var response = await HttpClient.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var value = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.True(response.IsSuccessStatusCode);
        }
    }
}
