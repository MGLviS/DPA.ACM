using DPA.ACM.DOMAIN.Core.Entities;
using DPA.ACM.DOMAIN.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DPA.ACM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculoController : ControllerBase
    {
        private readonly IVehiculoRepository _vehiculoRepository;

        public VehiculoController(IVehiculoRepository vehiculoRepository)
        {
            _vehiculoRepository = vehiculoRepository;
        }

        [HttpGet("ListarVehiculos")]
        public async Task<IActionResult> GetAll()
        {
            var vehiculo = await _vehiculoRepository.GetAll();
            return Ok(vehiculo);
        }

        [HttpGet("BuscarVehiculo/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var vehiculo = await _vehiculoRepository.GetById(id);
            return Ok(vehiculo);
        }

        [HttpPost("InsertarVehiculo")]
        public async Task<IActionResult> Insert(Vehiculo vehiculo)
        {
            var result = await _vehiculoRepository.InsertV(vehiculo);
            if (!result)
                return BadRequest();

            return Ok(result);
        }
        [HttpDelete("EliminarVehiculo")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _vehiculoRepository.Delete(id);
            return Ok(result);
        }

       
    }
}
