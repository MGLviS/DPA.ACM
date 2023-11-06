using DPA.ACM.DOMAIN.Core.DTO;
using DPA.ACM.DOMAIN.Core.Entities;

namespace DPA.ACM.DOMAIN.Core.Interfaces
{
    public interface IServicioService
    {
        Task<IEnumerable<CatalogoServicioDTO>> CatalogoServicio(int id);
        Task<IEnumerable<ListaServicioDTO>> ListaServicio();
    }
}