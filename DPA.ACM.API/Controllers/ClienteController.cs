using DPA.ACM.DOMAIN.Core.Entities;
using DPA.ACM.DOMAIN.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DPA.ACM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _ClienteRepository;

        public ClienteController(IClienteRepository ClienteRepository)
        {
            _ClienteRepository = ClienteRepository;
        }


        [HttpPost("Registrar usuario")]
        public async Task<IActionResult> RegisterCliente(Cliente Cliente)
        {
            var result = await _ClienteRepository.RegisterCliente(Cliente);
            if (!result)
                return BadRequest(result);
            return Ok(result);
        }


        [HttpDelete("Eliminar por ID")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var result = await _ClienteRepository.Eliminar(id);
            if (!result)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("Listar todos los Clientes")]
        public async Task<IActionResult> GetAll()
        {
            var cliente = await _ClienteRepository.GetAll();
            return Ok(cliente);
        }
        [HttpPost("Actualizar")]
        public async Task<IActionResult> Actualizar(int id, Cliente cliente)
        {
            var rows = await _ClienteRepository.Actualizar(id,  cliente);
            return Ok(rows);
        }




    }
}
