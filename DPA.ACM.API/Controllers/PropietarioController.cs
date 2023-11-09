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
        
        [HttpPost("RegisterPropietario")]
        
        public async Task<IActionResult> RegPropietario(PropRegisterDTO propRegisterDTO)
        {
            var result = await _propietarioService.RegPropietario(propRegisterDTO);
            if (!result)
                return BadRequest(result);
            return Ok(result);

        }

        [HttpDelete("Delete{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var result = await _propietarioService.Delete(id);
            if (!result)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult>
            SignIn([FromBody] PropietarioAuthDTO propietarioAuthDTO)
        {
            var result = await _propietarioService.SignIn(propietarioAuthDTO);

            if (result == null)
                return BadRequest("Credenciales inválidas");
            return Ok(result);
        }

        [HttpPut("Update{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PropietarioUpdateDTO propietarioUpdateDTO)
        {
            var rows = await _propietarioService.Update(id, propietarioUpdateDTO);
            return Ok(rows);
        }
    }
}
