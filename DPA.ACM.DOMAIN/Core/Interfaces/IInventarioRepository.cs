using DPA.ACM.DOMAIN.Core.Entities;

namespace DPA.ACM.DOMAIN.Core.Interfaces
{
    public interface IInventarioRepository
    {
        Task<IEnumerable<Inventario>> GetAll();
    }
}