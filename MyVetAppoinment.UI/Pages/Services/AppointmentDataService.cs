using MyVetAppoinment.Shared.Domain;
using System.Net.Http.Json;
using System.Text.Json;

namespace MyVetAppoinment.UI.Pages.Services
{
    public class AppointmentDataService : IAppointmentDataService
    {
        private const string ApiUrl = "api/v1/appointments/";
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

        public async Task<Appointment?> GetPetAppointment(Guid appointmentId)
        {
            return await httpClient.GetFromJsonAsync<Appointment>($"https://localhost:7193/{ApiUrl}" + appointmentId);
        }
        
        public async void AddAppointment(Appointment appointment, Guid petId, Guid cabinetId)
        {
            await httpClient.PostAsJsonAsync($"https://localhost:7193/{ApiUrl}" + petId + "/" + cabinetId, appointment);
        }
        public async void EditAppointment(Guid appointmentId, Appointment appointment)
        {

            await httpClient.PutAsJsonAsync($"https://localhost:7193/{ApiUrl}" + appointmentId, appointment);


        }

        public async void DeleteAppointment(Guid appointmentId)
        {
            await httpClient.DeleteAsync($"https://localhost:7193/{ApiUrl}" + appointmentId);
        }
    }
}
