using Microsoft.Extensions.DependencyInjection;
using RestauranteMaMonolitica.Web.BL.Interfaces;
using RestauranteMaMonolitica.Web.BL.Services;
using RestaurantePro.Factura.Domain.Interface;
using RestaurantePro.Factura.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
