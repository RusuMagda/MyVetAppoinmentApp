using FluentAssertions;
using MyVetAppointment.API.DTOs;
using System.Net.Http.Json;

namespace IntegrationTests
{
    public class PetControllerTests : BaseIntegrationTests
    {
        private const string ApiUrl = "api/pets";

        [Fact]
        public async void When_CreatedPet_Then_ShouldReturnPetInTheGetRequest()
        {
            var petDto = new CreatePetDto
            {
                Name = "Azorel",
                Birthdate = DateTime.Now,
                OwnerId = 12
            };

            var createPetResponse = await HttpClient.PostAsJsonAsync(ApiUrl, petDto);

            var getPetResult = await HttpClient.GetAsync(ApiUrl);

            createPetResponse.EnsureSuccessStatusCode();
            createPetResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);

            getPetResult.EnsureSuccessStatusCode();
            var pets = await getPetResult.Content.ReadFromJsonAsync<List<CreatePetDto>>();
            pets.Count.Should().Be(1);
            pets.Should().HaveCount(1);
            pets.Should().NotBeNull();
        }
    }
}
