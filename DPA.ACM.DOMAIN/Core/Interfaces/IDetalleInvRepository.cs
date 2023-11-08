using DPA.ACM.DOMAIN.Core.Entities;

namespace DPA.ACM.DOMAIN.Core.Interfaces
{
    public interface IDetalleInvRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<DetalleInventario>> GetAll();
        Task<IEnumerable<DetalleInventario>> GetById(int id);
        Task<bool> Insert(int idrepuesto, int cantidad, DetalleInventario dinventario);
        Task<bool> Update(int id, DetalleInventario dinventario);
    }
}