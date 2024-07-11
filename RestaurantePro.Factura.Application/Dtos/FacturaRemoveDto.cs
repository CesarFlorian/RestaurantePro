using RestauranteSol.Common.Data.Base;

namespace RestaurantePro.Factura.Application.Dtos
{
    public class FacturaRemoveDto 
    {

        public  int id { get; set; }

        public int? delete_user { get; set; }
        public DateTime? delete_date { get; set; }

        public bool? deleted { get; set; }
    }
}
