namespace RestaurantePro.Factura.Application.Dtos
{
    public class FacturaUpdateDto 
    {
        public int id { get; set; }

        public DateTime? modify_date { get; set; }

        public int? modify_user { get; set; }

        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }

    }
}
