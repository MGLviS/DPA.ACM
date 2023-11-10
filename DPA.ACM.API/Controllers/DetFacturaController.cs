using DPA.ACM.DOMAIN.Core.DTO;
using DPA.ACM.DOMAIN.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DPA.ACM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetFacturaController : ControllerBase
    {
        private readonly IDetFacturaService _detFacService;

        public DetFacturaController(IDetFacturaService detFacService)
        {
            _detFacService = detFacService;
        }

        [HttpGet("GetByID/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _detFacService.GetById(id);
            return Ok(result);
        }

        [HttpGet("GetByFac/{idFac}")]
        public async Task<IActionResult> GetByFac(int idFac)
        {
            var result = await _detFacService.GetByFactura(idFac);
            return Ok(result);
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(CrearDetFacturaDTO detFac)
        {
            var result = await _detFacService.Insert(detFac);
            if(!result)
                return BadRequest(result);
            return Ok(result);
        }
    }
}
