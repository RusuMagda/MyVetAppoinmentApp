using Microsoft.EntityFrameworkCore;
using MyVetAppoinment.Entities;

namespace MyVetAppoinment.Data
{
    public class MyVetAppointmentDatabaseContext : DbContext
    {
        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<Cabinet> Cabinets { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Drug> Drugs { get; set; }

        public DbSet<Pet> Pets { get; set; }

        public DbSet<Shop> Shops { get; set; }
    }
}
