using Microsoft.AspNetCore.Mvc;
using RestaurantePro.Factura.Application.Dtos;
using RestaurantePro.Factura.Application.Interfaces;

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

        [HttpGet]
        [Route("GetFacturas")]
        public IActionResult GetFacturas()
        {
            var result = this.facturaService.GetFacturas();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return NotFound(result.Message);
            }
        }

        [HttpGet]
        [Route("GetFacturaById/{id}")]
        public IActionResult GetFacturaById(int id)
        {
            var result = this.facturaService.GetFactura(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return NotFound(result.Message);
            }
        }

        
        [HttpPost("SaveFactura")]
       
        public IActionResult Post([FromBody] FacturaSaveDto facturaSaveDto)
        {
           
        
            var result = this.facturaService.saveFactura(facturaSaveDto);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpPut]
        [Route("UpdateFactura")]
        public IActionResult UpdateFactura([FromBody] FacturaUpdateDto facturaUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = this.facturaService.updateFactura(facturaUpdateDto);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpDelete]
        [Route("RemoveFactura")]
        public IActionResult RemoveFactura([FromBody] FacturaRemoveDto facturaRemoveDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = this.facturaService.removeFactura(facturaRemoveDto);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
    }
}
