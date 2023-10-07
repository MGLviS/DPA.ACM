using DPA.ACM.DOMAIN.Core.DTO;
using DPA.ACM.DOMAIN.Core.Entities;
using DPA.ACM.DOMAIN.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DPA.ACM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventarioController : ControllerBase
    {
        private readonly IInventarioRepository _inventarioRepository;
        //private readonly IInventarioService _inventarioService;

        public InventarioController(IInventarioRepository inventarioRepository)
        {
            _inventarioRepository = inventarioRepository;
        }



        [HttpGet("ListarInventario")]
        public async Task<IActionResult> GetAll()
        {
            var inventario = await _inventarioRepository.GetAll();
            return Ok(inventario);
        }

        [HttpPost("GuardarInventario")]
        public async Task<ActionResult> InsertInventario(Inventario inventario)
        {
            var result = await _inventarioRepository.Insert(inventario);
            if (!result)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("Buscar/{name}")]
        public async Task<ActionResult> SearchInventario(string name)
        {
            var inventario = await _inventarioRepository.GetByName(name);
            return Ok(inventario);
        }

        [HttpDelete("EliminarInventario")]
        public async Task<ActionResult> DeleteInventario(int id)
        {
            var result = await _inventarioRepository.Delete(id);
            if (!result)
                return BadRequest(result);
            return Ok(result);
        }

    }
}
