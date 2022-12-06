using Xunit;
using IntegrationTests.Configure;

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
            var request = "/api/Drugs";
            // Act
            var response = await HttpClient.GetAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestGetDrugAsync()
        {
            // Arrange
            var request = "/api/Drugs/fe1bdfc5-5424-4410-ab46-3cf1f98ac59a";
            // Act
            var response = await HttpClient.GetAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestPostDrugAsync()
        {
            // Arrange
            var request = new
            {
                Url = "/api/Drugs",
                Body = new
                {
                    Id = Guid.NewGuid(),
                    DrugName = "testdrug",
                    Description = "test description",
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
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestPutDrugAsync()
        {
            // Arrange
            var request = new
            {
                Url = "/api/Drugs/fe1bdfc5-5424-4410-ab46-3cf1f98ac59a",
                Body = new
                {
                    DrugName = "CorpetVet",
                    Description = "Supliment nutritional cu rol paliativ antitumoral si de sustinere a sistemului imunitar.",
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
            response.EnsureSuccessStatusCode();
        }
    }

}