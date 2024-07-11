using Microsoft.AspNetCore.Mvc;
using RestauranteMaMonolitica.Web.BL.Interfaces;
using RestaurantePro.Factura.Domain.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestauranteSol.Factura.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly IFacturaService facturaService;
        public FacturaController(IFacturaService facturaService)
        {
            this.facturaService = facturaService;
        }
        // GET: api/<FacturaController>
        [HttpGet]

        
        public IActionResult Get()
        {
            var result = this.facturaService.GetFacturas();
            if (result.Sucess) 
            { 
              return BadRequest(result);
            }
            else 
                return Ok(result);
            
        }

        // GET api/<FacturaController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var result = this.facturaService.GetFactura(id);
            if (result.Sucess)
            {
                return BadRequest(result);
            }
            else
                return Ok(result);
        }

        // POST api/<FacturaController>
        [HttpPost("Save Course")]
        public void Post([FromBody] Factura.Application.Dtos.CourseDtoSave)
        {
        }

        // PUT api/<FacturaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FacturaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
