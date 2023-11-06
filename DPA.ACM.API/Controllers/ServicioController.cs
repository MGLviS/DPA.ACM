using DPA.ACM.API.Controllers;
using DPA.ACM.DOMAIN.Core.Entities;
using DPA.ACM.DOMAIN.Core.Interfaces;
using DPA.ACM.DOMAIN.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DPA.ACM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {
        private readonly IServicioService _servicioService;

        public ServicioController(IServicioService servicioService)
        {
            _servicioService = servicioService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var servicios = await _servicioService.ListaServicio();
            return Ok(servicios);
        }

        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var servicios = await _servicioService.CatalogoServicio(id);
            return Ok(servicios);
        }
    }
}


//private readonly IServicioRepository _servicioRepository;

//public ServicioController(IServicioRepository servicioRepository)
//{
//    _servicioRepository = servicioRepository;
//}

//[HttpGet("ListarServicios")]
//public async Task<IActionResult> GetAll()
//{
//    var servicios = await _servicioRepository.GetAll();
//    return Ok(servicios);
//}

//[HttpGet("BuscarServicios/{id}")]
//public async Task<IActionResult> GetById(int id)
//{
//    var servicio = await _servicioRepository.GetById(id);
//    return Ok(servicio);
//}

//[HttpPost("InsertarServicios")]
//public async Task<IActionResult> Insert(Servicio servicio)
//{
//    var result = await _servicioRepository.InsertS(servicio);
//    if (!result)
//        return BadRequest(result);
//    return Ok(result);
//}


//[HttpDelete("EliminarServicios")]
//public async Task<IActionResult> Delete(int id)
//{
//    var result = await _servicioRepository.Delete(id);
//    return Ok(result);
//}