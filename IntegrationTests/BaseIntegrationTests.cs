using Microsoft.AspNetCore.Mvc.Testing;
using MyVetAppointment.API.Controllers;
using MyVetAppointment.Infrastructure;

namespace IntegrationTests
{
    public class BaseIntegrationTests
    {
        protected HttpClient HttpClient { get; private set; }
        protected BaseIntegrationTests()
        {
            var application = new WebApplicationFactory<PetsController>().WithWebHostBuilder(builder => { });
            HttpClient = application.CreateClient();

            CleanDatabases();
        }

        private void CleanDatabases()
        {
            var databaseContext = new DatabaseContext();
            databaseContext.Pets.RemoveRange(databaseContext.Pets.ToList());
            databaseContext.Clients.RemoveRange(databaseContext.Clients.ToList());
            databaseContext.Cabinets.RemoveRange(databaseContext.Cabinets.ToList());
            databaseContext.Appointments.RemoveRange(databaseContext.Appointments.ToList());
            databaseContext.Shops.RemoveRange(databaseContext.Shops.ToList());
            databaseContext.Drugs.RemoveRange(databaseContext.Drugs.ToList());
            databaseContext.SaveChanges();
        }
    }
}