using Microsoft.EntityFrameworkCore;
using MyVetAppointment.Domain.Entities;

namespace MyVetAppointment.Infrastructure.Data
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Appointment> Appointments => Set<Appointment>();

        public DbSet<Cabinet> Cabinets => Set<Cabinet>();

        public DbSet<Client> Clients => Set<Client>();

        public DbSet<Drug> Drugs => Set<Drug>();

        public DbSet<Pet> Pets => Set<Pet>();

        public DbSet<Shop> Shops => Set<Shop>();

        public void SaveAsync()
        {
            SaveChangesAsync();
        }
    }
}
