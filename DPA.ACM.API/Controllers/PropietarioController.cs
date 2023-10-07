using DPA.ACM.DOMAIN.Core.DTO;
using DPA.ACM.DOMAIN.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DPA.ACM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropietarioController : ControllerBase
    {
        
        private readonly IPropietarioService _propietarioService;
        
        public PropietarioController(IPropietarioService propietarioService)
        {
            _propietarioService = propietarioService;
        }
        
        [HttpPost("RegistrarPropietario")]
        
        public async Task<IActionResult> RegPropietario([FromBody] PropRegisterDTO propRegisterDTO)
        {
            var result = await _propietarioService.RegPropietario(propRegisterDTO);
            if (!result)
                return BadRequest(result);
            return Ok(result);

        }
    }
}
