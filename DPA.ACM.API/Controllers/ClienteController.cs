
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

        
       [HttpPost("RegisterClient")]
       public async Task<IActionResult> RegisterCliente(ClienteRegisterDTO clienteRegisterDTO)
       {
           var result = await
                _clienteService.CreateClient(clienteRegisterDTO);
           if (!result)
               return BadRequest(result);
           return Ok(result);
       }

        
        [HttpDelete("Delete{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
           var result = await _clienteService.Delete(id);
           if (!result)
               return BadRequest(result);

           return Ok(result);
        }
        
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
 
        [HttpPut("Update{id}")]
        public async Task<IActionResult> UpdateClient(int id, [FromBody] ClienteUpdateDTO clienteUpdate)
        {
            var rows = await _clienteService.UpdateClient(id, clienteUpdate);
            return Ok(rows);
        }
        [HttpGet("GetCustom")]
        public async Task<IActionResult> GetCustom(string inputSearch)
        {
            var cliente = await _clienteService.GetByNaApDniRuc(inputSearch);
            return Ok(cliente);
        }

        [HttpGet("GetFacturasByClient")]
        public async Task<ActionResult> GetFacturasByCliente(int idCliente)
        {
            var cliente = await _clienteService.GetFactxClient(idCliente);
            if (cliente == null)
                return NotFound();
            return Ok(cliente);
        }







    }
}
