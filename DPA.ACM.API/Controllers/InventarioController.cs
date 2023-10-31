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


        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CrearInventarioDTO crearInventarioDTO)
        {
            var result = await _inventarioService.RegistroInventario(crearInventarioDTO);
            if (!result)
                return BadRequest();
            return Ok(result);
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

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ActualizarInventarioDTO actualizarDTO)
        {
            var result = await _inventarioService.ActualizarInvetario(id, actualizarDTO);
            if (!result)
                return BadRequest();
            return Ok(result);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _inventarioService.EliminarInventario(id);
            
            if(!result) 
                return BadRequest();
            
            return Ok(result);
        }

        /*


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
