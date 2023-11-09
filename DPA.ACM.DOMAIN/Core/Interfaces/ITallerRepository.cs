using DPA.ACM.DOMAIN.Core.Entities;

namespace DPA.ACM.DOMAIN.Core.Interfaces
{
    public interface ITallerRepository
    {
        Task<IEnumerable<Taller>> GetAll();
        Task<bool> RegisterTaller(Taller taller);
        Task<bool> Delete(int id);
        Task<Taller> GetByName(string nomtaller);
        Task<bool> Update(int id, Taller taller);

    }
}
