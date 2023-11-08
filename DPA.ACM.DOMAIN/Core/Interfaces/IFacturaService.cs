using DPA.ACM.DOMAIN.Core.DTO;

namespace DPA.ACM.DOMAIN.Core.Interfaces

{
    public interface IFacturaService
    {
        Task<IEnumerable<FacturaDTO>> ShowFacturas();
        Task<IEnumerable<FacturasStateDTO>> ShowFactActivas();
        Task<IEnumerable<FacturasStateDTO>> ShowFactCanceladas();
        Task<IEnumerable<FactHistorialDTO>> GetCustom(string inputSearch);
        Task<bool> SetCancelFactura(int id, FactCancelDTO factCancelDTO);
        Task<bool> CreateFactura(FactRegisterDTO factRegisterDTO);
    }
}