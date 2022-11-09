using MyVetAppoinment.Data;
using MyVetAppoinment.Entities;

namespace MyVetAppoinment.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly MyVetAppointmentDatabaseContext context;

        public AppointmentRepository(MyVetAppointmentDatabaseContext context)
        {
            this.context = context;
        }

        public void Add(Appointment appointment)
        {
            this.context.Appointments.Add(appointment);
            this.context.SaveChanges();
        }

        public void Update(Appointment appointment)
        {
            this.context.Appointments.Update(appointment);
            this.context.SaveChanges();
        }

        public void Delete(Appointment appointment)
        {
            this.context.Appointments.Remove(appointment);
            this.context.SaveChanges();
        }
    }
}
