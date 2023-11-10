using DPA.ACM.DOMAIN.Core.Entities;

namespace DPA.ACM.DOMAIN.Core.Interfaces
{
    public interface IDetFacturaRepository
    {
        Task<IEnumerable<DetallesFactura>> GetByFactura(int id);
        Task<IEnumerable<DetallesFactura>> GetByID(int id);
        Task<bool> Insert(DetallesFactura detFactura);
    }
}