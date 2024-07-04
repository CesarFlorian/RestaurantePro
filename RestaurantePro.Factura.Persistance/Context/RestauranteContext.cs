using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantePro.Factura.Persistance.Context
{
    public class RestauranteContext : DbContext
    {
        public RestauranteContext(DbContextOptions<RestauranteContext> options) : base(options)

        {









        }

        #region "DbSets"
        public DbSet<Domain.Entities.Factura> Factura { get; set; }
        #endregion

    }
}
