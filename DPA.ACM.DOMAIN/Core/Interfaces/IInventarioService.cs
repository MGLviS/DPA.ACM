using DPA.ACM.DOMAIN.Core.DTO;

namespace DPA.ACM.DOMAIN.Core.Interfaces
{
    public interface IInventarioService
    {
        Task<InventarioResponseDTO> InventarioRespuesta(InventarioResponseDTO inventarioResponseDTO);
    }
}