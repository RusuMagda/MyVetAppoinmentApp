using Microsoft.EntityFrameworkCore;
using MyVetAppoinment.Domain.Entities;
using MyVetAppointment.Application;
using System.Runtime.CompilerServices;

namespace MyVetAppoinment.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly IDatabaseContext context;

        public PetRepository(IDatabaseContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Pet pet)
        {
            await context.Pets.AddAsync(pet);
        }

        public void Update(Pet pet)
        {
            this.context.Pets.Update(pet);
        }

        public async void Delete(Guid id)
        {
            var pet = await this.context.Pets.FirstOrDefaultAsync(p => p.Id == id);
            if (pet != null)
            {
                this.context.Pets.Remove(pet);
            }
        }

        public async Task<IReadOnlyCollection<Pet>> GetAllAsync()
        {
            return await context.Pets.ToListAsync();
        }

        public async Task<Pet?> GetByIdAsync(Guid id)
        {
            return await context.Pets.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyCollection<Appointment>> GetAppointmentsAsync(Guid id)
        {
            return await (context.Appointments.Where(a => a.PetId == id)).ToListAsync();
        }

        public void Save()
        {
            context.SaveAsync();
        }
    }
}
