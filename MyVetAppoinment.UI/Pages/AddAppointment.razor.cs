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
        public IAppointmentDataService AppointmentDataService { get; set; }


        [Parameter]
        public String? year { get; set; }
        [Parameter]
        public String? month { get; set; }
        [Parameter]
        public String? day { get; set; }
        [Parameter]
        public String? hour { get; set; }
        [Parameter]
        public String? minut { get; set; }


        public EventCallback<string> ValueChanged { get; set; }

        private Appointment appointment = new();




        protected async Task SaveApp()
        {


            DateTime date1 = new DateTime(2023, Int32.Parse(month), Int32.Parse(day), Int32.Parse(hour), Int32.Parse(minut), 0, DateTimeKind.Utc);
            
            appointment.StartTime = Convert.ToDateTime(date1);
           
            appointment.EndTime = Convert.ToDateTime(date1);
            AppointmentDataService.AddAppointment(appointment,PetId,CabinetId);
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
