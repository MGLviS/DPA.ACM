using DPA.ACM.DOMAIN.Core.DTO;

namespace DPA.ACM.DOMAIN.Core.Interfaces
{
    public interface IDetFacturaService
    {
        Task<IEnumerable<ListarDetFacturaDTO>> GetByFactura(int id);
        Task<IEnumerable<ListarDetFacturaDTO>> GetById(int id);
        Task<bool> Insert(CrearDetFacturaDTO detFactFTO);
    }
}