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
        public DateTime Start { get; set; }

        public String error { get; set; }
        [Parameter]
        public String Description { get; set; }

        [Parameter]
        public TimeOnly time { get; set; }






        private Appointment model = new Appointment();
        public List<Appointment> Appointments { get; set; } = default!;

        public bool ok = false;

        protected async override Task OnInitializedAsync()
        {
            model.StartTime = DateTime.Today;
        }
        protected async Task OnSubmit()
        {
            if (model.StartTime.DayOfWeek == DayOfWeek.Saturday || model.StartTime.DayOfWeek == DayOfWeek.Sunday)
            {
                error = "Inchis sambata si duminica";
              
            }
            else
                if (model.StartTime.Hour < 9 || model.StartTime.Hour > 16)
            {
                error = "In afara orelor de program";
               
            }
            else
            {
                model.EndTime = model.StartTime + TimeSpan.FromMinutes(30);
                Console.WriteLine(model.EndTime);
                model.CabinetId = CabinetId;
                model.PetId = PetId;
               
                error = null;
                ok = false;
               


                var app = await AppointmentDataService.GetAppointmentByCabinetId((Guid)CabinetId);
                if (app != null)
                {

                    Appointments = app.ToList();
                    foreach (var a in Appointments)
                        if (a.StartTime == model.StartTime)
                        {
                            Console.WriteLine("__________exista");
                            error = "Exista deja programare";
                            ok = true;
                            break;

                        }
                        else if (a.EndTime.Year == model.EndTime.Year && a.EndTime.Month == model.EndTime.Month && a.EndTime.Day == model.EndTime.Day && (((a.EndTime.TimeOfDay - model.StartTime.TimeOfDay).Minutes > 0 && (a.EndTime.TimeOfDay - model.StartTime.TimeOfDay).Minutes < 30) || ((model.EndTime.TimeOfDay - a.StartTime.TimeOfDay).Minutes > 0 && (model.EndTime.TimeOfDay - a.StartTime.TimeOfDay).Minutes < 30)))
                        {
                            Console.WriteLine("__________exista desfasurare");
                            error = "Exista deja programare in desfasurare";
                            ok = true;
                            break;

                        }

                }
                Console.WriteLine("hai ua");
                if (ok == false)
                {
                    Console.WriteLine(")))))))))");
                    AppointmentDataService?.AddAppointment(model, (Guid)PetId, (Guid)CabinetId);


                    NavigationManager.NavigateTo("/");
                }

            }

        }

      

        public async Task Cancel()
        {
            await Task.Delay(1000);
            NavigationManager.NavigateTo("/");
        }
    }
}
