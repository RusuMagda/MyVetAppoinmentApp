using Xunit;
using MyVetAppoinment.IntegrationTest;
using Newtonsoft.Json;
using MyVetAppoinment.Domain.Entities;

namespace IntegrationTests
{
    public class ClientTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private HttpClient HttpClient;

        public ClientTests(CustomWebApplicationFactory<Program> factory) {
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
        public async Task TestPutStockItemAsync()
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

        //[Fact]
        //public async Task TestDeleteClientAsync()
        //{
        //    // Arrange

        //    var postRequest = new
        //    {
        //        Url = "/api/Clients",
        //        Body = new
        //        {
        //            Id = new Guid("39ffa571-e14c-4e48-88f4-88e37666c75f"),
        //            Name = "testuser",
        //            EMail = "test@yahoo.com",
        //            PhoneNumber = "0123456789"
        //        }
        //    };

        //    // Act
        //    var postResponse = await HttpClient.PostAsync(postRequest.Url, ContentHelper.GetStringContent(postRequest.Body));
        //    var jsonFromPostResponse = await postResponse.Content.ReadAsStringAsync();

        //    var singleResponse = JsonConvert.DeserializeObject<SingleResponse<Client>>(jsonFromPostResponse);

        //    var deleteResponse = await HttpClient.DeleteAsync(string.Format("/api/Clients/39ffa571-e14c-4e48-88f4-88e37666c75f", singleResponse.Entity.Id));

        //    // Assert
        //    postResponse.EnsureSuccessStatusCode();

        //    Assert.False(singleResponse.DidError);

        //    deleteResponse.EnsureSuccessStatusCode();
        //}
    }

}
