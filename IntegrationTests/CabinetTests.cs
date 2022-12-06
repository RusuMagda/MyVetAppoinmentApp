using MyVetAppoinment.IntegrationTest;
using Xunit;

namespace IntegrationTests
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
            response.EnsureSuccessStatusCode();
        }
        [Fact]
        public async Task TestGetCabinetAsync()
        {
            // Arrange
            var request = "/api/Cabinets/3937a85c-fc53-40d9-b588-2fd95fa86518";
            // Act
            var response = await HttpClient.GetAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
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
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestGetCabinetClientsAsync()
        {
           // Arrange
          var request = "/api/Cabinets/3937a85c-fc53-40d9-b588-2fd95fa86518/clients";
           // Act
           var response = await HttpClient.GetAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
        }


        //[Fact]
        //public async Task TestDeleteCabinetAsync()
        //{
        //    // Arrange

        //    var postRequest = new
        //    {
        //        Url = "/api/Cabinets",
        //        Body = new
        //        {
        //            Id = new Guid("39ffa571-e14c-4e48-88f4-88e37666c75f"),
        //            Name = "TestVet",
        //            Address = "Str. Stefan Cel Mare"
        //        }
        //    };

        //    // Act
        //    var postResponse = await HttpClient.PostAsync(postRequest.Url, ContentHelper.GetStringContent(postRequest.Body));
        //    var jsonFromPostResponse = await postResponse.Content.ReadAsStringAsync();

        //    var singleResponse = JsonConvert.DeserializeObject<Cabinet>(jsonFromPostResponse);

        //    var deleteResponse = await HttpClient.DeleteAsync(string.Format("/api/Cabinets/39ffa571-e14c-4e48-88f4-88e37666c75f", singleResponse.Entity.Id));

        //   // Assert
        //   postResponse.EnsureSuccessStatusCode();

            

        //   deleteResponse.EnsureSuccessStatusCode();
        //}







    }
}
