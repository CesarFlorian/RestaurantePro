using Microsoft.Extensions.DependencyInjection;


using RestaurantePro.Factura.Application.Interfaces;
using RestaurantePro.Factura.Application.Services;
using RestaurantePro.Factura.Domain.Interface;
using RestaurantePro.Factura.Persistance.Repositories;


namespace RestaurantePro.Factura.IOC.Dependencies
{
    public static class FacturaDependencies
    {
        public static void AddFacturaDependency(this IServiceCollection service) 
        { 
          service.AddScoped<IFacturaRepository,FacturaRepository>();  
          service.AddTransient<IFacturaService,FacturaService>();  
        }
    }
}
