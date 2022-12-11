using MyVetAppoinment.Domain.Entities;
﻿using Microsoft.EntityFrameworkCore;
using MyVetAppointment.Application;

namespace MyVetAppoinment.Repositories 
{ 
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly IDatabaseContext context;
        public AppointmentRepository(IDatabaseContext databaseContext) 
        {
            context = databaseContext;
        }
        public async Task AddAsync(Appointment appointment)
        {
            await context.Appointments.AddAsync(appointment);
        }

        public async Task<IReadOnlyCollection<Appointment>> GetAllAsync()
        {
            return await context.Appointments.ToListAsync<Appointment>();
        }

        public async Task<Appointment> GetByIdAsync(Guid id)
        {
            return await context.Appointments.FirstOrDefaultAsync(a => a.Id == id);
        }

        public void Update(Appointment appointment)
        {
            context.Appointments.Update(appointment);
        }

        public async void Delete(Guid id)
        {
            var appointment = await context.Appointments.FirstOrDefaultAsync(a => a.Id == id);
            if (appointment != null)
            {
                context.Appointments.Remove(appointment);
            }

            //await context.Appointments.Remove(appointment);
        }
        public void Save()
        {
            context.SaveAsync();
        }
    }
}
