using DPA.ACM.DOMAIN.Core.DTO;

namespace DPA.ACM.DOMAIN.Core.Interfaces
{
    public interface IInventarioService
    {
        Task<IEnumerable<InventarioTablaDTO>> ShowTable();

        Task<IEnumerable<InventarioTablaDTO>> GetByName(string name);

        Task<bool> RegistroInventario(CrearInventarioDTO inventarioDTO);

        Task<bool> ActualizarInvetario(int id, ActualizarInventarioDTO inventarioDTO);

        Task<bool> EliminarInventario(int id);

    }
}