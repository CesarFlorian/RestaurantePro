using System.Text.Json.Serialization;

namespace RestaurantePro.WebUi.Models
{
    public class BaseResult <TModel>
    {
        public bool success { get; set; }
        public string? message { get; set; }

    

        [JsonPropertyName("data")]
        public TModel? result { get; set; }
    }
}
