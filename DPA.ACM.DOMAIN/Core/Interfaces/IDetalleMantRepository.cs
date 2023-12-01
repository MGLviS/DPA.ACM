using DPA.ACM.DOMAIN.Core.Entities;

namespace DPA.ACM.DOMAIN.Core.Interfaces
{
    public interface IDetalleMantRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<ReparacionMantenimiento>> GetAll();
        Task<IEnumerable<ReparacionMantenimiento>> GetById(int id);
        Task<bool> Insert(ReparacionMantenimiento repman);
        Task<bool> Update(int id, ReparacionMantenimiento repman);
    }
}