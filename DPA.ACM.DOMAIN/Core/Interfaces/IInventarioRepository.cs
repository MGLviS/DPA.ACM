using DPA.ACM.DOMAIN.Core.Entities;

namespace DPA.ACM.DOMAIN.Core.Interfaces
{
    public interface IInventarioRepository
    {
        Task<IEnumerable<Inventario>> GetAll();
        Task<bool> Insert(Inventario inventario);
        Task<bool> Delete(int id);
        Task<IEnumerable<Inventario>> GetByName(string nrepuesto);
        Task<bool> Update(int id, Inventario inventario);
        //Task<Inventario> GetById(int id);
    }
}