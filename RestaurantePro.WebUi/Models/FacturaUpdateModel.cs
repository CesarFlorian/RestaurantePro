namespace RestaurantePro.WebUi.Models
{
    public class FacturaUpdateModel
    {
        public int id { get; set; }
        public int changeUser { get; set; }
        public DateTime changeDate { get; set; }
        public int total { get; set; }
        public DateTime fecha { get; set; }
    }
}
