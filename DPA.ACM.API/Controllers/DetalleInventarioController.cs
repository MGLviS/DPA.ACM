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
    }
}
