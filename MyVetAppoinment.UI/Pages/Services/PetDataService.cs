using MyVetAppoinment.Shared.Domain;
using System.Net.Http.Json;
using System.Text.Json;

namespace MyVetAppoinment.UI.Pages.Services
{
    public class PetDataService : IPetDataService
    {
        private const string ApiUrl = "api/v1/pets/";
        private readonly HttpClient httpClient;

        public PetDataService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IEnumerable<Pet>?> GetAllPets()
        {
            return await JsonSerializer
                 .DeserializeAsync<IEnumerable<Pet>>
                 (await httpClient.GetStreamAsync($"https://localhost:7193/{ApiUrl}"),
                 new JsonSerializerOptions()
                 {
                     PropertyNameCaseInsensitive = true,
                 });

        }
        public async Task<IEnumerable<Appointment>?> GetAllAppointments(Guid petId)
        {
            return await JsonSerializer
                .DeserializeAsync<IEnumerable<Appointment>>
                (await httpClient.GetStreamAsync($"https://localhost:7193/{ApiUrl}" + petId + "/appointments"),
                new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true,
                });
        }

        public async Task<Pet?> GetPetDetail(Guid petId)
        {
            return await httpClient.GetFromJsonAsync<Pet>($"https://localhost:7193/{ApiUrl}" + petId);
        }
        public async Task<Pet?> GetPetId(Guid id, String name)
        {
            return await httpClient.GetFromJsonAsync<Pet>($"https://localhost:7193/{ApiUrl}" + id + "/" + name);
        }
        public async Task<IEnumerable<Pet>?> GetPetsClient(Guid id)
        {
            return await JsonSerializer
                .DeserializeAsync<IEnumerable<Pet>>
                (await httpClient.GetStreamAsync($"https://localhost:7193/{ApiUrl}" + id + "/pets"),
                new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true,
                });
        }
        public async void AddPet(Pet pet)
        {

            await httpClient.PostAsJsonAsync($"https://localhost:7193/{ApiUrl}", pet);


        }
        public async void EditPet(Guid petId, Pet pet)
        {

            await httpClient.PutAsJsonAsync($"https://localhost:7193/{ApiUrl}" + petId, pet);


        }

        public async void DeletePet(Guid petId)
        {
            await httpClient.DeleteAsync($"https://localhost:7193/{ApiUrl}" + petId);
        }
    }
}
