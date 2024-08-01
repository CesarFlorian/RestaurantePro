using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace RestaurantePro.WebUi.Helpers
{
    public class ApiHelper
    {
        private readonly HttpClientHandler _httpClientHandler;
        private readonly string _baseApiUrl;

        public ApiHelper(string baseApiUrl)
        {
            _httpClientHandler = new HttpClientHandler();
            _httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyError) => true;
            _baseApiUrl = baseApiUrl;
        }

        public async Task<T> GetApiResultAsync<T>(string endpoint) where T : class
        {
            using (var httpClient = new HttpClient(_httpClientHandler))
            {
                var response = await httpClient.GetAsync($"{_baseApiUrl}{endpoint}");
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    try
                    {
                        return JsonSerializer.Deserialize<T>(apiResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    }
                    catch (JsonException)
                    {
                        
                    }
                }
            }
            return null;
        }

        public async Task<bool> PostOrPutApiResultAsync<T>(string endpoint, T model, bool isPut = false) where T : class
        {
            using (var httpClient = new HttpClient(_httpClientHandler))
            {
                var jsonContent = JsonSerializer.Serialize(model);
                var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response;

                if (isPut)
                {
                    response = await httpClient.PutAsync($"{_baseApiUrl}{endpoint}", content);
                }
                else
                {
                    response = await httpClient.PostAsync($"{_baseApiUrl}{endpoint}", content);
                }

                return response.IsSuccessStatusCode;
            }
        }
    }
}
