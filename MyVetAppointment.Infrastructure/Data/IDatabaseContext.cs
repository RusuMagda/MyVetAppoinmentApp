using Microsoft.EntityFrameworkCore;
using MyVetAppointment.Domain.Entities;

namespace MyVetAppointment.Infrastructure.Data
{
    public interface IDatabaseContext
    {
        public DbSet<Appointment> Appointments { get; }

        public DbSet<Cabinet> Cabinets { get; }

        public DbSet<Client> Clients { get; }

        public DbSet<Drug> Drugs { get; }

        public DbSet<Pet> Pets { get; }

        public DbSet<Shop> Shops { get; }

        void SaveAsync();
    }
}
