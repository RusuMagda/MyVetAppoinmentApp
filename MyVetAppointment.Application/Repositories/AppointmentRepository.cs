using MyVetAppoinment.Domain.Entities;
using MyVetAppointment.Application;

namespace MyVetAppoinment.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly IDatabaseContext context;

        public AppointmentRepository(IDatabaseContext context)
        {
            this.context = context;
        }

        public void Add(Appointment appointment)
        {
            this.context.Appointments.Add(appointment);
        }

        public void Update(Appointment appointment)
        {
            this.context.Appointments.Update(appointment);
        }

        public void Delete(Appointment appointment)
        {
            this.context.Appointments.Remove(appointment);
        }

        public List<Appointment> GetAll()
        {
            return context.Appointments.ToList();
        }

        public Appointment Get(Guid id)
        {
            return context.Appointments.Find(id);
        }


        public void Save()
        {
            context.Save();
        }
    }
}
