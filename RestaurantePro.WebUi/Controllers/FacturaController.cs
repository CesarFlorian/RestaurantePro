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
                            // Manejo de error de deserialización
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
        public async Task<ActionResult> Create()
        {
            try
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
                                // Manejo de error de deserialización
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
            catch (Exception ex)
            {
                // Manejo de excepción general
                ViewBag.ErrorMessage = $"Error al crear la factura: {ex.Message}";
                return View();
            }
        }

        // POST: FacturaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FacturaSaveModel facturaSave)
        {
            try
            {
                // Lógica para guardar la nueva factura
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Manejo de excepción general
                ViewBag.ErrorMessage = $"Error al guardar la factura: {ex.Message}";
                return View();
            }
        }

        // GET: FacturaController/Edit/5
        public ActionResult Edit(int id)
        {
            // Lógica para mostrar la vista de edición
            return View();
        }

        // POST: FacturaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FacturaSaveModel facturaSave)
        {
            try
            {
                // Lógica para actualizar la factura
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Manejo de excepción general
                ViewBag.ErrorMessage = $"Error al actualizar la factura: {ex.Message}";
                return View();
            }
        }

        // GET: FacturaController/Delete/5
        public ActionResult Delete(int id)
        {
            // Lógica para mostrar la vista de eliminación
            return View();
        }

        // POST: FacturaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // Lógica para eliminar la factura
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Manejo de excepción general
                ViewBag.ErrorMessage = $"Error al eliminar la factura: {ex.Message}";
                return View();
            }
        }
    }
}
