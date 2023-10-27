using DPA.ACM.DOMAIN.Core.DTO;

namespace DPA.ACM.DOMAIN.Core.Interfaces
{
    public interface IInventarioService
    {
        Task<IEnumerable<InventarioTablaDTO>> ShowTable();
        Task<IEnumerable<InventarioTablaDTO>> GetByName(string name);
    }
}