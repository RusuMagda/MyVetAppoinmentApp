using Microsoft.EntityFrameworkCore;
using MyVetAppointment.Domain.Entities;
using MyVetAppointment.Infrastructure.Data;

namespace MyVetAppointment.Infrastructure.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly IDatabaseContext context;

        public AppointmentRepository(IDatabaseContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Appointment appointment)
        {
            await context.Appointments.AddAsync(appointment);
        }

        public async Task<IReadOnlyCollection<Appointment>> GetAllAsync()
        {
            return await context.Appointments.ToListAsync<Appointment>();
        }

        public async Task<Appointment?> GetByIdAsync(Guid id)
        {
            return await context.Appointments.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async void Delete(Guid id)
        {
            var appointment = await context.Appointments.FirstOrDefaultAsync(a => a.Id == id);
            if (appointment != null) 
            {
                context.Appointments.Remove(appointment);
            }
        }


        public void Save()
        {
            context.SaveAsync();
        }
    }
}





