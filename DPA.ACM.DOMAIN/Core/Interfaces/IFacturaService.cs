using DPA.ACM.DOMAIN.Core.DTO;

namespace DPA.ACM.DOMAIN.Core.Interfaces

{
    public interface IFacturaService
    {
        Task<IEnumerable<FacturaDTO>> ShowFacturas();
    }
}