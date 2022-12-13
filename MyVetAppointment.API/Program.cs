using Microsoft.EntityFrameworkCore;
using MyVetAppoinment.Repositories;
using MyVetAppointment.Application;
using MyVetAppointment.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<IDatabaseContext, DatabaseContext>(
    options => options.UseSqlite(builder.Configuration.GetConnectionString("MyVetAppointmentDb"),
           b => b.MigrationsAssembly(typeof(DatabaseContext).Assembly.FullName)));
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<ICabinetRepository, CabinetRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IDrugRepository, DrugRepository>();
builder.Services.AddScoped<IPetRepository, PetRepository>();
builder.Services.AddScoped<IShopRepository, ShopRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("cabinetsCors", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("cabinetsCors");
app.UseAuthorization();

app.MapControllers();

app.Run();
public partial class Program { }


