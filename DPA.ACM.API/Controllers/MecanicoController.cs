using DPA.ACM.DOMAIN.Core.DTO;
using DPA.ACM.DOMAIN.Core.Entities;
using DPA.ACM.DOMAIN.Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DPA.ACM.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MecanicoController : ControllerBase
    {
        //private readonly IMecanicoRepository _mecanicoRepository;

        private readonly IMecanicoService _mecanicoService;

        //public MecanicoController(IMecanicoRepository mecanicoRepository)
        public MecanicoController(IMecanicoService mecanicoService)
        {
            _mecanicoService = mecanicoService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var mecanico = await _mecanicoService.ShowMecanico();
            return Ok(mecanico);
        }

       [HttpPost("RegisterMecanico")]
        public async Task<IActionResult> CreateMecanico(MecanicoRegisterDTO mecanicoRegisterDTO)
        {
            var result = await _mecanicoService.CreateMecanico(mecanicoRegisterDTO);
            if (!result)
                return BadRequest(result);
            return Ok(result);
        }

        /*       [HttpGet("Buscar/{name}")]
              public async Task<ActionResult> SearchTaller(string nomMecanico)
              {
                  var mecanico = await _mecanicoRepository.GetByName(nomMecanico);
                  return Ok(mecanico);
              }*/

        [HttpDelete("Delete{id}")]
              public async Task<IActionResult> DeleteMecanico(int id)
              {
                  var result = await _mecanicoService.Delete(id);
                  if (!result)
                      return BadRequest(result);
                  return Ok(result);
              }
        [HttpPut("Update{id}")]
        public async Task<IActionResult> UpdateMecanico(int id, [FromBody] MecanicoUpdateDTO mecanicoUpdate)
        {
            var rows = await _mecanicoService.UpdateMecanico(id, mecanicoUpdate);
            return Ok(rows);
        }

    }
}
