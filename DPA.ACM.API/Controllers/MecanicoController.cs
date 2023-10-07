using DPA.ACM.DOMAIN.Core.Entities;
using DPA.ACM.DOMAIN.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DPA.ACM.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MecanicoController : ControllerBase
    {
        private readonly IMecanicoRepository _mecanicoRepository;

        public MecanicoController(IMecanicoRepository mecanicoRepository)
        {
            _mecanicoRepository = mecanicoRepository;
        }

        [HttpGet("ListarMecanico")]
        public async Task<IActionResult> GetAll()
        {
            var mecanico = await _mecanicoRepository.GetAll();
            return Ok(mecanico);
        }

        [HttpPost("GuardarMecanico")]
        public async Task<ActionResult> InsertMecanico(Mecanico mecanico)
        {
            var result = await _mecanicoRepository.Insert(mecanico);
            if (!result)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("Buscar/{name}")]
        public async Task<ActionResult> SearchTaller(string nomMecanico)
        {
            var mecanico = await _mecanicoRepository.GetByName(nomMecanico);
            return Ok(mecanico);
        }

        [HttpDelete("EliminarTaller")]
        public async Task<ActionResult> DeleteMecanico(int id)
        {
            var result = await _mecanicoRepository.Delete(id);
            if (!result)
                return BadRequest(result);
            return Ok(result);
        }
    }
}
