using DPA.ACM.DOMAIN.Core.Entities;

namespace DPA.ACM.DOMAIN.Core.Interfaces
{
    public interface IFacturaRepository
    {
        Task<IEnumerable<Factura>> GetAll();
        Task<IEnumerable<Factura>> GetFactActivas();
        Task<IEnumerable<Factura>> GetFactCancelas();
        Task<IEnumerable<Factura>> GetCustom(string inputSearch);
        Task<bool> SetCancelFactura(int facturaId, Factura factura);
        Task<bool> RegisterFactura(Factura factura);
    }
}