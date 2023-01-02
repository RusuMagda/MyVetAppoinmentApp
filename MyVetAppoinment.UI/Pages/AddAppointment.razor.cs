using Microsoft.AspNetCore.Components;
using MyVetAppoinment.Shared.Domain;
using MyVetAppoinment.UI.Pages.Services;

namespace MyVetAppoinment.UI.Pages
{
    public partial class AddAppointment
    {
        [Parameter]
        public Guid PetId { get; set; }
        [Parameter]
        public Guid CabinetId { get; set; }

        [Inject]
        public IAppointmentDataService? AppointmentDataService { get; set; }


        [Parameter]
        public String? Month { get; set; }
        [Parameter]
        public String? Day { get; set; }
        [Parameter]
        public String? Hour { get; set; }
        [Parameter]
        public String? Minute { get; set; }


        public EventCallback<string> ValueChanged { get; set; }

        private Appointment appointment = new();

        protected async Task SaveApp()
        {
            DateTime date1 = new DateTime(DateTime.Now.Year, Int32.Parse(Month!), Int32.Parse(Day!), Int32.Parse(Hour!), Int32.Parse(Minute!), 0, DateTimeKind.Utc);
            
            appointment.StartTime = Convert.ToDateTime(date1);
            appointment.EndTime = Convert.ToDateTime(date1);

            appointment.CabinetId = CabinetId;
            appointment.PetId = PetId;

            AppointmentDataService?.AddAppointment(appointment, PetId, CabinetId);
             await Task.Delay(2000);
            NavigationManager.NavigateTo("/");
        }

        public async Task Cancel()
        {
            await Task.Delay(1000);
            NavigationManager.NavigateTo("/");
        }
    }
}
