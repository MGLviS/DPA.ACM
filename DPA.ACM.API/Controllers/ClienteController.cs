
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
    public class ClienteController : ControllerBase
    {
        //private readonly IClienteRepository _ClienteRepository;
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        /*
       [HttpPost("Registrar usuario")]
       public async Task<IActionResult> RegisterCliente(Cliente Cliente)
       {
           var result = await _clienteService.ShowClients(Cliente);
           if (!result)
               return BadRequest(result);
           return Ok(result);
       }
        */
        /*
        [HttpDelete("Eliminar por ID")]
        public async Task<IActionResult> Eliminar(int id)
        {
           var result = await _ClienteRepository.Eliminar(id);
           if (!result)
               return BadRequest(result);

           return Ok(result);
        }
         */
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
           var cliente = await _clienteService.ShowClients();
           return Ok(cliente);
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult>
            SignIn([FromBody] ClienteAuthDTO clienteAuthDTO)
        {
            var result = await
                _clienteService.SignIn(clienteAuthDTO);

            if (result == null)
                return BadRequest("Credenciales inválidas");

            return Ok(result);

        }
        /*
[HttpPut("Actualizar")]
public async Task<IActionResult> Actualizar(int id, Cliente cliente)
{
var rows = await _ClienteRepository.Actualizar(id,  cliente);
return Ok(rows);
}

*/


    }
}
