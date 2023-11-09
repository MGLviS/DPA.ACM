using DPA.ACM.DOMAIN.Core.DTO;
using DPA.ACM.DOMAIN.Core.Entities;
using DPA.ACM.DOMAIN.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DPA.ACM.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class TallerController : ControllerBase
    {
        private readonly ITallerService _tallerService;

        public TallerController(ITallerService tallerService)
        {
            _tallerService = tallerService;
        }



        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var taller = await _tallerService.ShowTalleres();
            return Ok(taller);
        }

        [HttpPost("RegisterTaller")]
        public async Task<ActionResult> InsertTaller(TallerRegisterDTO tallerRegisterDTO)
        {
            var result = await _tallerService.RegistrarTaller(tallerRegisterDTO);
            if (!result)
                return BadRequest(result);
            return Ok(result);
        }

 /*       [HttpGet("Buscar/{name}")]
        public async Task<ActionResult> SearchTaller(string nomtaller)
        {
            var taller = await _tallerRepository.GetByName(nomtaller);
            return Ok(taller);
        }*/

        [HttpDelete("Delete{id}")]
        public async Task<ActionResult> DeleteTaller(int id)
        {
            var result = await _tallerService.Delete(id);
            if (!result)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPut("Update{id}")]
        public async Task<IActionResult> UpdateTaller(int id, [FromBody]TallerUpdateDTO tallerUpdateDTO)
        {
            var rows = await _tallerService.UpdateTaller(id, tallerUpdateDTO);
            return Ok(rows);
        }

    }
}
