using DPA.ACM.DOMAIN.Core.DTO;
using DPA.ACM.DOMAIN.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DPA.ACM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepMantenimientoController : ControllerBase
    {
        private readonly IDetalleMantService _repmantService;

        public RepMantenimientoController(IDetalleMantService repmantService)
        {
            _repmantService = repmantService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var repman = await _repmantService.GetAll();
            return Ok(repman);
        }

        [HttpGet("GetbyId/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var repman = await _repmantService.GetById(id);
            return Ok(repman);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Insert(RepMantDTO repman)
        {
            var result = await _repmantService.Insert(repman);
            if (!result) return BadRequest();

            return Ok(result);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var repman = await _repmantService.Delete(id);
            return Ok(repman);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, UpdateRepMantDTO repMantDTO)
        {
            var result = await _repmantService.Update(id, repMantDTO);
            return Ok(result);
        }

    }
}
