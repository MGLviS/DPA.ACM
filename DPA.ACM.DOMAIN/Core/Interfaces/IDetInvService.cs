using DPA.ACM.DOMAIN.Core.DTO;

namespace DPA.ACM.DOMAIN.Core.Interfaces
{
    public interface IDetInvService
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<DIListarDTO>> GetAll();
        Task<IEnumerable<DIListarDTO>> GetById(int id);
        Task<bool> Insert(int idrepuesto, int cantidad, DICrearDTO detalleDTO);
        Task<bool> Update(int id, DIActualizarDTO detalleDTO);
    }
}