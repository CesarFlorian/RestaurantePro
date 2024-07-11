using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantePro.Factura.Persistance.Exceptions
{
    public class FacturaDbExceptions : Exception
    {
        public FacturaDbExceptions(string message) : base(message)
        {

        }
    }
}
