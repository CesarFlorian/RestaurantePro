namespace RestaurantePro.Factura.Application.Dtos
{
    public abstract class FacturaBaseDto : BaseModel
    {

        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }






    }
}
