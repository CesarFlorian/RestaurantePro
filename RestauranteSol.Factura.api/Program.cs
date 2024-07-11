using Microsoft.EntityFrameworkCore;
using RestaurantePro.Factura.Persistance.Context;
using RestaurantePro.Factura.IOC.Dependencies;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<RestauranteContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("RestauranteContext")));

// Agregar las dependencias del Modulo de Factura
builder.Services.AddFacturaDependency();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
