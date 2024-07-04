
using RestauranteSol.Common.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace RestauranteMaMonolitica.Web.Data.Entities
{
    public class Factura : BaseEntity<int>
    {


        public override int id { get; set; }
        public decimal Total { get; set; }
        public DateOnly Fecha { get; set; }

    }
}