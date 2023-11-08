using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DPA.ACM.DOMAIN.Core.Interfaces;
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
    }
}

