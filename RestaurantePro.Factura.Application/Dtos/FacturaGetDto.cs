namespace RestaurantePro.Factura.Application.Dtos
{
    public class FacturaGetDto
    {
        public int id { get; set; }
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }

        public DateTime creation_date { get; set; }


    }
}
