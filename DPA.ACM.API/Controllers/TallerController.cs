using DPA.ACM.DOMAIN.Core.Entities;
using DPA.ACM.DOMAIN.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DPA.ACM.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class TallerController : ControllerBase
    {
        private readonly ITallerRepository _tallerRepository;

        public TallerController(ITallerRepository tallerRepository)
        {
            _tallerRepository = tallerRepository;
        }



        [HttpGet("ListarTaller")]
        public async Task<IActionResult> GetAll()
        {
            var taller = await _tallerRepository.GetAll();
            return Ok(taller);
        }

        [HttpPost("GuardarTaller")]
        public async Task<ActionResult> InsertTaller(Taller taller)
        {
            var result = await _tallerRepository.Insert(taller);
            if (!result)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("Buscar/{name}")]
        public async Task<ActionResult> SearchTaller(string nomtaller)
        {
            var taller = await _tallerRepository.GetByName(nomtaller);
            return Ok(taller);
        }

        [HttpDelete("EliminarTaller")]
        public async Task<ActionResult> DeleteTaller(int id)
        {
            var result = await _tallerRepository.Delete(id);
            if (!result)
                return BadRequest(result);
            return Ok(result);
        }

    }
}
