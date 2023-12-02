using DPA.ACM.DOMAIN.Core.DTO;
using DPA.ACM.DOMAIN.Core.Interfaces;
using DPA.ACM.DOMAIN.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace DPA.ACM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramacionController : ControllerBase
    {
        private readonly IProgramacionService _programacionService;

        public ProgramacionController(IProgramacionService programacionService)
        {
            _programacionService = programacionService;
        }

        [HttpPost("RegisterProgramacion")]

        public async Task<IActionResult> RegProgramacion(PrograRegisterDTO prograRegisterDTO)
        {
            var result = await _programacionService.RegProgramacion(prograRegisterDTO);
            if (!result)
                return BadRequest(result);
            return Ok(result);

        }

        [HttpDelete("Delete{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var result = await _programacionService.Delete(id);
            if (!result)
                return BadRequest(result);

            return Ok(result);
        }
              

        [HttpPut("Update{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PrograUpdateDTO prograUpdateDTO)
        {
            var rows = await _programacionService.Update(id, prograUpdateDTO);
            return Ok(rows);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var programacion = await _programacionService.ShowProgramacion();
            return Ok(programacion);
        }
    }
}
