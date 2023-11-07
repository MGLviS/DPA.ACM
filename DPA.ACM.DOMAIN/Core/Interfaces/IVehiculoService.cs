using DPA.ACM.DOMAIN.Core.DTO;
using DPA.ACM.DOMAIN.Core.Entities;

namespace DPA.ACM.DOMAIN.Core.Interfaces
{
    public interface IVehiculoService
    {
        Task<bool> ActualizarVehiculo(int id, ActualizarVehiculoDTO vehiculoDTO);
        Task<IEnumerable<ListarVehiculoDTO>> ListaVehiculo();
        Task<bool> EliminarVehiculo(int id);
        Task<IEnumerable<ListarVehiculoDTO>> GetById(int id);
        Task<bool> RegistroVehiculo(CrearVehiculoDTO vehiculoDTO);
    }
}