using RestauranteSol.Common.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantePro.Factura.Domain.Interface
{
    public interface IFacturaRepository : IBaseRepository<Factura.Domain.Entities.Factura,int>
    {
       
    }
}
