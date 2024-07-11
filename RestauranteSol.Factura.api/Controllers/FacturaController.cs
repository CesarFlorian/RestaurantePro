using Microsoft.AspNetCore.Mvc;

using RestaurantePro.Factura.Domain.Interface;
using RestaurantePro.Factura.Application;
using RestaurantePro.Factura.Application.Dtos;
using RestaurantePro.Factura.Application.Interfaces;

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

        [HttpGet("GetFactura")]


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


        [HttpGet("GetFacturabyId")]
        public IActionResult Get(int id)
        {
            var result = this.facturaService.GetFactura(id);
            if (result.Sucess)
            {
                return BadRequest(result);
            }
            else
                return Ok(result);
        }


        [HttpPost("SaveFactura")]
        public IActionResult Post([FromBody] FacturaSaveDto facturaSaveDto)
        {
            facturaSaveDto.ChangeDate = DateTime.Now;
            facturaSaveDto.ChangeUser = 1;
            var result = this.facturaService.saveFactura(facturaSaveDto);
            if (result.Sucess)
            {
                return BadRequest(result);
            }
            else
                return Ok(result);
        }


        [HttpPost("UpdateFactura")]
        public IActionResult Put(FacturaUpdateDto facturaUpdateDto)
        {
            var result = this.facturaService.updateFactura(facturaUpdateDto);
            if (result.Sucess)
            {
                return BadRequest(result);
            }
            else
                return Ok(result);
        }

        [HttpPost("RemoveFactura")]
        public IActionResult Delete(FacturaRemoveDto facturaRemoveDto)
        {
            var result = this.facturaService.removeFactura(facturaRemoveDto);
            if (result.Sucess)
            {
                return BadRequest(result);
            }
            else
                return Ok(result);
        }
    }


    
}


