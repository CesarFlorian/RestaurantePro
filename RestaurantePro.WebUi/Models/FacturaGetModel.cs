namespace RestaurantePro.WebUi.Models
{
    public class FacturaGetModel
    {
        public int id { get; set; }
        public decimal  total { get; set; }
        public DateTime fecha { get; set; }
        public int creation_user { get; set; }

        public DateTime creation_date { get; set; }

        public DateTime? modify_date { get; set; }


        public int? modify_user { get; set; }
        public int? delete_user { get; set; }
        public DateTime? delete_date { get; set; }

        public bool? deleted { get; set; }

    }
}

