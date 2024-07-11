using RestauranteSol.Common.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantePro.Factura.Domain.Entities
{
    public class Factura : AuditEntity<int>
    {
        [Column("IdFactura")]
        public override int id { get; set; }

        public decimal Total { get; set; }
        public DateOnly Fecha { get; set; }




    }
}
