namespace RestauranteMaMonolitica.Web.Data.Models
{
    public  class FacturaGetModel 
    {
        public int IdFactura { get; set; }
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }

        public DateTime creation_date { get; set; }


    }
}
