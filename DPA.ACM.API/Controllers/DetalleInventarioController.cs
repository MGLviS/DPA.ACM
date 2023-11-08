using DPA.ACM.DOMAIN.Core.DTO;
using DPA.ACM.DOMAIN.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DPA.ACM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleInventarioController : ControllerBase
    {
        private readonly IDetInvService _detService;

        public DetalleInventarioController(IDetInvService detService)
        {
            _detService = detService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _detService.GetAll();
            return Ok(result);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _detService.GetById(id);
            return Ok(result);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(int idrepuesto, int cantidad, DICrearDTO detalleDTO)
        {
            var result = await _detService.Insert(idrepuesto, cantidad, detalleDTO);
            if (!result)
                return BadRequest();
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(int id, DIActualizarDTO detalleDTO)
        {
            var result = await _detService.Update(id, detalleDTO);
            if (!result)
                return BadRequest();
            return Ok(result);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _detService.Delete(id);
            if (!result)
                return BadRequest();
            return Ok(result);
        }

    }
}
