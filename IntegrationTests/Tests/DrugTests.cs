using Xunit;

namespace IntegrationTests.Tests
{
    public class DrugTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private HttpClient HttpClient;

        public DrugTests(CustomWebApplicationFactory<Program> factory)
        {
            HttpClient = factory.CreateClient();
        }


        [Fact]
        public async Task TestGetDrugsAsync()
        {
            // Arrange
            var request = "/api/v1/Drugs";
            // Act
            var response = await HttpClient.GetAsync(request);

            // Assert
            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task TestGetDrugAsync()
        {
            // Arrange
            var request = "/api/v1/Drugs/fe1bdfc5-5424-4410-ab46-3cf1f98ac59a";
            // Act
            var response = await HttpClient.GetAsync(request);

            // Assert
            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task TestPostDrugAsync()
        {
            // Arrange
            var request = new
            {
                Url = "/api/v1/Drugs",
                Body = new
                {
                    Id = Guid.NewGuid(),
                    DrugName = "testdrug",
                    DrugDescription = "test description",
                    Stock = 100,
                    Price = 100,
                    SaleForm = "pastile",
                    Quantity = 100,
                    QuantityMeasure = "pastile"
                }
            };

            // Act
            var response = await HttpClient.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var value = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task TestPutDrugAsync()
        {
            // Arrange
            var request = new
            {
                Url = "/api/v1/Drugs/fe1bdfc5-5424-4410-ab46-3cf1f98ac59a",
                Body = new
                {
                    DrugName = "CorpetVet",
                    DrugDescription = "Supliment nutritional cu rol paliativ antitumoral si de sustinere a sistemului imunitar.",
                    Stock = 98,
                    Price = 160,
                    SaleForm = "pastile",
                    Quantity = 90,
                    QuantityMeasure = "pastile"
                }
            };

            // Act
            var response = await HttpClient.PutAsync(request.Url, ContentHelper.GetStringContent(request.Body));

            // Assert
            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task TestDrugAppointmentAsync()
        {
            // Arrange
            var request = "/api/v1/Drugs/45454ce7-7fa1-478b-bfaa-021eea996f16";
            // Act
            var response = await HttpClient.DeleteAsync(request);

            // Assert
            Assert.True(response.IsSuccessStatusCode);
        }
    }

}