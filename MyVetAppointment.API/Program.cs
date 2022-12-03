using Microsoft.EntityFrameworkCore;
using MyVetAppoinment.Repositories;
using MyVetAppointment.Application;
using MyVetAppointment.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddScoped<IDatabaseContext, DatabaseContext>();
builder.Services.AddDbContext<IDatabaseContext, DatabaseContext>(
    options => options.UseSqlite(builder.Configuration.GetConnectionString("MyVetAppointmentDb"),
           b => b.MigrationsAssembly(typeof(DatabaseContext).Assembly.FullName)));
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<ICabinetRepository, CabinetRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IDrugRepository, DrugRepository>();
builder.Services.AddScoped<IPetRepository, PetRepository>();
builder.Services.AddScoped<IShopRepository, ShopRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
