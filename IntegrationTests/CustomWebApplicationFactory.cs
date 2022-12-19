using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyVetAppointment.Infrastructure.Data;
using Xunit;
using static IntegrationTests.DbSeed;
[assembly: CollectionBehavior(DisableTestParallelization = true)]
namespace IntegrationTests;
public class CustomWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var descriptor = services.SingleOrDefault(
                d => d.ServiceType ==
                     typeof(DbContextOptions<DatabaseContext>));

            if (descriptor != null)
            {
                services.Remove(descriptor);
            }

            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseInMemoryDatabase("InMemoryDbForTesting");
            });

            var serviceProvider = services.BuildServiceProvider();
            using var scope = serviceProvider.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
            try
            {
                if (context.Database.ProviderName != "Microsoft.EntityFrameworkCore.InMemory")
                {
                    context.Database.Migrate();
                }

                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                SeedClients(context);
                SeedCabinets(context);
                SeedDrugs(context);
                SeedPets(context);
                SeedAppointments(context);
                SeedShops(context);
            }
            catch (Exception)
            {
                //log errors
                throw;
            }
        });

        builder.UseEnvironment("Development");
    }
}