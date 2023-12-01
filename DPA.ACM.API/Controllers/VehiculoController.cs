using DPA.ACM.DOMAIN.Core.DTO;
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
        private readonly IVehiculoService _vehiculoService;

        public VehiculoController(IVehiculoService vehiculoService)
        {
            _vehiculoService = vehiculoService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var vehiculo = await _vehiculoService.ListaVehiculo();
            return Ok(vehiculo);
        }

        [HttpGet("GetbyId/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var vehiculo = await _vehiculoService.GetById(id);
            return Ok(vehiculo);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Insert(CrearVehiculoDTO vehiculo)
        {
            var result = await _vehiculoService.RegistroVehiculo(vehiculo);
            if (!result)
                return BadRequest();

            return Ok(result);
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _vehiculoService.EliminarVehiculo(id);
            return Ok(result);
        }
        //PUT
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, ActualizarVehiculoDTO vehiculo)
        {
            var result = await _vehiculoService.ActualizarVehiculo(id, vehiculo);
            return Ok(result);
        }
       
    }
}
