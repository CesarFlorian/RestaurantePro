using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using RestaurantePro.WebUi.Helpers;
using RestaurantePro.WebUi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace RestaurantePro.WebUi.Controllers
{
    public class FacturaController : Controller
    {
        private readonly ApiHelper _apiHelper;

        public FacturaController()
        {
            _apiHelper = new ApiHelper("http://localhost:5049/api/Factura/");
        }

        // GET: FacturaController
        public async Task<ActionResult> Index()
        {
            var result = await _apiHelper.GetApiResultAsync<FacturaListGetResult>("GetFactura");
            if (result == null)
            {
                ViewBag.ErrorMessage = "Error al obtener los datos de la factura.";
                return View();
            }

            return View(result.result ?? new List<FacturaGetModel>());
        }

        // GET: FacturaController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var result = await _apiHelper.GetApiResultAsync<FacturaGetResult>($"GetFacturabyId?id={id}");
            if (result == null)
            {
                ViewBag.ErrorMessage = "Error al obtener los datos de la factura.";
                return View();
            }

            return View(result.result);
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
                return View(facturaSave); 
            }

            var isSuccess = await _apiHelper.PostOrPutApiResultAsync("SaveFactura", facturaSave);
            if (!isSuccess)
            {
                ViewBag.ErrorMessage = "Error al guardar la factura.";
                return View(facturaSave);
            }

            return RedirectToAction(nameof(Index));
        }

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

            var isSuccess = await _apiHelper.PostOrPutApiResultAsync($"UpdateFactura?id={id}", facturaUpdate, isPut: true);
            if (!isSuccess)
            {
                ViewBag.ErrorMessage = "Error al actualizar la factura.";
                return View(facturaUpdate);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: FacturaController/Delete/5
        public ActionResult Delete(int id)
        {
           
            return View();
        }
    }
}
