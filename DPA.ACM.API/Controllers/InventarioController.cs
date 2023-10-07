using DPA.ACM.DOMAIN.Core.DTO;
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
        private readonly IInventarioService _inventarioService;

        /*public InventarioController(IInventarioRepository inventarioRepository)
        {
            _inventarioRepository = inventarioRepository;
        }*/

        public InventarioController(IInventarioService inventarioService)
        {
            _inventarioService = inventarioService;
        }



        [HttpGet("ListarInventario")]
        /*public async Task<IActionResult> GetAll()
        {
            var inventario = await _inventarioRepository.GetAll();
            return Ok(inventario);
        }*/
        public async Task<ActionResult> GetAll([FromBody]InventarioResponseDTO)
    }
}
