using Microsoft.EntityFrameworkCore;
using MyVetAppointment.Application;
using MyVetAppoinment.Domain.Entities;

namespace MyVetAppointment.Infrastructure
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {

        public DatabaseContext()
        {
            this.Database.EnsureCreated();
        }
        public DbSet<Appointment> Appointments => Set<Appointment>();

        public DbSet<Cabinet> Cabinets => Set<Cabinet>();

        public DbSet<Client> Clients => Set<Client>();

        public DbSet<Drug> Drugs => Set<Drug>();

        public DbSet<Pet> Pets => Set<Pet>();

        public DbSet<Shop> Shops => Set<Shop>();

        public void Save()
        {
            SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = MyVetAppointment.Db");
        }
    }
}
