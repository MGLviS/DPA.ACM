using DPA.ACM.DOMAIN.Core.Entities;

namespace DPA.ACM.DOMAIN.Core.Interfaces
{
    public interface ITallerRepository
    {
        Task<IEnumerable<Taller>> GetAll();
        Task<bool> Insert(Taller taller);
        Task<bool> Delete(int id);
        Task<Inventario> GetByName(string nrepuesto);
    }
}
