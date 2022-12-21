using MyVetAppoinment.Shared.Domain;

namespace MyVetAppoinment.UI.Pages.Services
{
    public interface IAppointmentDataService
    {
        Task<IEnumerable<Appointment>?> GetAllAppointments();
      

        Task<Appointment?> GetPetAppointment(Guid appointmentId);
        


        void AddAppointment(Appointment appointmentId, Guid petId, Guid cabinetId);
        void EditAppointment(Guid appointmentId, Appointment appointment);
        void DeleteAppointment(Guid appointmentId);
    }
}
