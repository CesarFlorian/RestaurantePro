using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantePro.WebUi.Models;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace RestaurantePro.WebUi.Controllers
{
    public class FacturaController : Controller
    {
        private readonly HttpClientHandler _httpClientHandler;

        public FacturaController()
        {
            _httpClientHandler = new HttpClientHandler();
            _httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyError) => true;
        }

        // GET: FacturaController
        public async Task<ActionResult> Index()
        {
            var facturaGetResult = new FacturaListGetResult();

            using (var httpClient = new HttpClient(_httpClientHandler))
            {
                var url = "http://localhost:5049/api/Factura/GetFactura";

                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();

                        try
                        {
                            facturaGetResult = JsonSerializer.Deserialize<FacturaListGetResult>(apiResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                        }
                        catch (JsonException ex)
                        {
                            ViewBag.ErrorMessage = $"Error de deserialización JSON: {ex.Message}";
                            return View();
                        }

                        if (!facturaGetResult.success)
                        {
                            ViewBag.ErrorMessage = facturaGetResult.message;
                            return View();
                        }
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Error al obtener los datos de la factura.";
                        return View();
                    }
                }
            }

            return View(facturaGetResult.result ?? new List<FacturaGetModel>());
        }

        // GET: FacturaController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var facturaGetResult = new FacturaGetResult();

            using (var httpClient = new HttpClient(_httpClientHandler))
            {
                var url = $"http://localhost:5049/api/Factura/GetFacturabyId?id={id}";

                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        try
                        {
                            facturaGetResult = JsonSerializer.Deserialize<FacturaGetResult>(apiResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                        }
                        catch (JsonException ex)
                        {
                            ViewBag.ErrorMessage = $"Error de deserialización JSON: {ex.Message}";
                            return View();
                        }

                        if (!facturaGetResult.success)
                        {
                            ViewBag.ErrorMessage = facturaGetResult.message;
                            return View();
                        }
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Error al obtener los datos de la factura.";
                        return View();
                    }
                }
            }

            return View(facturaGetResult.result);
        }

        // GET: FacturaController/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(FacturaSaveModel facturaSave)
        {
            if (!ModelState.IsValid)
            {
                return View(facturaSave); // Devuelve la vista con errores de validación
            }

            try
            {
                using (var httpClient = new HttpClient(_httpClientHandler))
                {
                    var url = "http://localhost:5049/api/Factura/SaveFactura";
                    var jsonContent = JsonSerializer.Serialize(facturaSave);
                    var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

                    var response = await httpClient.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        // Redirige a la lista después de una creación exitosa
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Error al guardar la factura.";
                        return View(facturaSave);
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Error al crear la factura: {ex.Message}";
                return View(facturaSave);
            }
        }

        // GET: FacturaController/Edit/5
       

        // POST: FacturaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, FacturaUpdateModel facturaUpdate)
        {
            if (id != facturaUpdate.id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(facturaUpdate);
            }

            try
            {
                using (var httpClient = new HttpClient(_httpClientHandler))
                {
                    var url = $"http://localhost:5049/api/Factura/UpdateFactura?id={id}";
                    var jsonContent = JsonSerializer.Serialize(facturaUpdate);
                    var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

                    var response = await httpClient.PutAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Error al actualizar la factura.";
                        return View(facturaUpdate);
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Error al actualizar la factura: {ex.Message}";
                return View(facturaUpdate);
            }
        }

        // GET: FacturaController/Delete/5
        public ActionResult Delete(int id)
        {
            // Lógica para mostrar la vista de eliminación
            return View();
        }
    }
}
