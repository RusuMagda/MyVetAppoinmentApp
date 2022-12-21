using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyVetAppointment.Infrastructure.Data;
using MyVetAppointment.Infrastructure.Repositories;
using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using MyVetAppointment.Application;
using MyVetAppointment.Infrastructure;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddDbContext<IDatabaseContext, DatabaseContext>(
    options => options.UseSqlite(builder.Configuration.GetConnectionString("MyVetAppointmentDb"),
           b => b.MigrationsAssembly(typeof(DatabaseContext).Assembly.FullName)));

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

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

public partial class Program
{
    protected Program(){}
}
































