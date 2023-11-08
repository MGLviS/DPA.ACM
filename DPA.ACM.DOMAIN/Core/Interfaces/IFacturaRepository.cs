using DPA.ACM.DOMAIN.Core.Entities;

namespace DPA.ACM.DOMAIN.Core.Interfaces
{
    public interface IFacturaRepository
    {
        Task<IEnumerable<Factura>> GetAll();
    }
}