using RestauranteMaMonolitica.Web.Data.Core;

namespace RestauranteMaMonolitica.Web.Data.Models
{
    public abstract class FacturaBaseModel : BaseModel
    {

        public decimal Total { get; set; }
        public DateOnly Fecha { get; set; }






    }
}
