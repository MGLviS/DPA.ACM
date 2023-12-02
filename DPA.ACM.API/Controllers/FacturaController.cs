using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DPA.ACM.DOMAIN.Core.DTO;
using DPA.ACM.DOMAIN.Core.Interfaces;
using DPA.ACM.DOMAIN.Core.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DPA.ACM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        //private readonly IFacturaRepository _facturaRepository;
        private readonly IFacturaService _facturaService;
        public FacturaController(IFacturaService facturaService)
        {
            _facturaService = facturaService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var factura = await _facturaService.ShowFacturas();
            return Ok(factura);
        }

        [HttpGet("GetActivas")]
        public async Task<IActionResult> GetActivas()
        {
            var factura = await _facturaService.ShowFactActivas();
            return Ok(factura);
        }

        [HttpGet("GetNoActivas")]
        public async Task<IActionResult> GetNoActivas()
        {
            var factura = await _facturaService.ShowFactCanceladas();
            return Ok(factura);
        }
        [HttpGet("GetCustom")]
        public async Task<IActionResult> GetCustom(string inputSearch)
        {
            var factura = await _facturaService.GetCustom(inputSearch);
            return Ok(factura);
        }
        [HttpPut("ChangeStateFactura{id}")]
        public async Task<IActionResult> ChangeStateFactura(int id, [FromBody] FactCancelDTO factCancelDTO)
        {
            var rows = await _facturaService.SetCancelFactura(id, factCancelDTO);
            return Ok(rows);
        }

        [HttpPost("RegisterFactura")]
        public async Task<IActionResult> RegisterFactura(FactRegisterDTO factRegisterDTO)
        {
            var result = await
                 _facturaService.CreateFactura(factRegisterDTO);
            if (!result)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("Count")]
        public async Task<IActionResult> Count()
        {
            var result = await _facturaService.GetFacturaReporte();
            return Ok(result);
        }
    }
}

