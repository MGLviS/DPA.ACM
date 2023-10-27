using DPA.ACM.DOMAIN.Core.DTO;
using DPA.ACM.DOMAIN.Core.Entities;
using DPA.ACM.DOMAIN.Core.Interfaces;
using DPA.ACM.DOMAIN.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DPA.ACM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventarioController : ControllerBase
    {

        private readonly IInventarioService _inventarioService;
        public InventarioController(IInventarioService inventarioService)
        {
            _inventarioService = inventarioService;
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var inventario = await _inventarioService.ShowTable();
            return Ok(inventario);
        }

        [HttpGet("GetByName/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var result = await _inventarioService.GetByName(name);
            return Ok(result);
        }

        /*

        [HttpPost("GuardarInventario")]
        public async Task<ActionResult> InsertInventario(Inventario inventario)
        {
            var result = await _inventarioRepository.Insert(inventario);
            if (!result)
                return BadRequest(result);
            return Ok(result);
        }


        [HttpDelete("EliminarInventario")]
        public async Task<ActionResult> DeleteInventario(int id)
        {
            var result = await _inventarioRepository.Delete(id);
            if (!result)
                return BadRequest(result);
            return Ok(result);
        }*/

    }
}
