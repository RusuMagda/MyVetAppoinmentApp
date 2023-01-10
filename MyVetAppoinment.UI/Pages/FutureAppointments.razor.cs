using Microsoft.AspNetCore.Components;
using MyVetAppoinment.Shared.Domain;
using MyVetAppoinment.UI.Pages.Services;

namespace MyVetAppoinment.UI.Pages
{
    public partial class FutureAppointments
    {
        public List<Pet> Pets { get; set; } = default!;
        [Inject]
        public IPetDataService PetDataService { get; set; } = default!;
        [Inject]
        public ICabinetDataService CabinetDataService { get; set; } = default!;
        public List<Cabinet> Cabinets { get; set; } = default!;

        public EventCallback<string> ValueChanged { get; set; }
        public String? Value { get; set; }
        public List<Appointment> Appointments { get; set; } = default!;
        public List<Appointment> AppointmentsFuture = new List<Appointment>();
        [Parameter]
        public Guid PetId { get; set; }
        protected async override Task OnInitializedAsync()
        {
            var result = await PetDataService.GetAllPets();
            if (result != null)
            {
                Pets = result.ToList();
            }
        }
        private Task OnValueChanged(ChangeEventArgs e)
        {
            var result = e.Value;
            if (result != null)
            {
                Value = result.ToString();
            }
            return ValueChanged.InvokeAsync(Value);
        }
        protected async Task Close()
        {
            if (Value != null)
            {
                AppointmentsFuture.Clear();
                var result = await PetDataService.GetAllAppointments(new Guid(Value));
                if (result != null)
                {
                    Appointments = result.ToList();
                    foreach (Appointment appointment in Appointments)
                    {
                        if (appointment.EndTime > DateTime.Now)
                        {
                            AppointmentsFuture.Add(appointment);
                        }

                    }
                }

                var CabinetsList = await CabinetDataService.GetAllCabinets();

                if (CabinetsList != null)
                {
                    Cabinets = CabinetsList.ToList();
                }
            }

        }

    }
}
