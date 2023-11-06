using DPA.ACM.DOMAIN.Core.Entities;
using DPA.ACM.DOMAIN.Infrastructure.Repositories;

namespace DPA.ACM.DOMAIN.Core.Interfaces
{
    public interface IServicioRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Servicio>> GetAll();
        Task<IEnumerable<Servicio>> GetById(int id);
        Task<bool> InsertS(Servicio servcio);
    }
}