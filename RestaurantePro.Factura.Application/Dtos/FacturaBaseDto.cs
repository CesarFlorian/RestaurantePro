namespace RestaurantePro.Factura.Application.Dtos
{
    public abstract class FacturaBaseDto : BaseModel
    {

        public decimal Total { get; set; }
        public DateOnly Fecha { get; set; }






    }
}
