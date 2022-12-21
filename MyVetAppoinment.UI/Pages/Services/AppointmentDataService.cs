using MyVetAppoinment.Shared.Domain;
using System.Net.Http.Json;
using System.Text.Json;

namespace MyVetAppoinment.UI.Pages.Services
{
    public class AppointmentDataService : IAppointmentDataService
    {
        private const string ApiUrl = "api/appointments/";
        private readonly HttpClient httpClient;

        public AppointmentDataService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IEnumerable<Appointment>?> GetAllAppointments()
        {
            return await JsonSerializer
                 .DeserializeAsync<IEnumerable<Appointment>>
                 (await httpClient.GetStreamAsync($"https://localhost:7193/{ApiUrl}"),
                 new JsonSerializerOptions()
                 {
                     PropertyNameCaseInsensitive = true,
                 });

        }

        public async Task<Appointment?> GetPetAppointment(Guid AppointmentId)
        {
            return await httpClient.GetFromJsonAsync<Appointment>($"https://localhost:7193/{ApiUrl}" + AppointmentId);
        }
        
        public async void AddAppointment(Appointment Appointment,Guid petId, Guid cabinetId)
        {

            await httpClient.PostAsJsonAsync($"https://localhost:7193/{ApiUrl}"+petId+"/"+cabinetId, Appointment);


        }
        public async void EditAppointment(Guid AppointmentId, Appointment Appointment)
        {

            await httpClient.PutAsJsonAsync($"https://localhost:7193/{ApiUrl}" + AppointmentId, Appointment);


        }

        public async void DeleteAppointment(Guid AppointmentId)
        {
            await httpClient.DeleteAsync($"https://localhost:7193/{ApiUrl}" + AppointmentId);
        }
    }
}
