using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyVetAppointment.Infrastructure.Repositories;

namespace MyVetAppointment.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<ICabinetRepository, CabinetRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IDrugRepository, DrugRepository>();
            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IShopRepository, ShopRepository>();

            //services.AddDbContext<IDatabaseContext, DatabaseContext>(m =>
            //    m.UseSqlite(configuration.GetConnectionString("MyVetAppointmentDb")),
            //    ServiceLifetime.Singleton);
            return services;
        }
    }
}
