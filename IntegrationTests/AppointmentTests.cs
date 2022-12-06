using MyVetAppoinment.IntegrationTest;
using Xunit;

namespace IntegrationTests
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
            response.EnsureSuccessStatusCode();
        }

        /*[Fact]
        public async Task TestGetAppointmentAsync()
        {
            // Arrange
            var request = "/api/Appointments/3837a85c-fc53-40d9-b588-2fd95fa86518";
            // Act
            var response = await HttpClient.GetAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestPostAppointmentAsync()
        {
            // Arrange
            var request = new
            {
                Url = "/api/Appointments/89fabd96-2503-4703-88a7-3f91191d6944/53979a62-50ea-4746-b1af-8e50098e0eee",
                Body = new
                {
                    Id = Guid.NewGuid(),
                    StartTime = "2022-12-06T16:47:02.959Z",
                    EndTime = "2022-12-06T17:47:02.959Z",
                    Description = "description"
                }
            };

            // Act
            var response = await HttpClient.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var value = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();
        }*/
    }
}
