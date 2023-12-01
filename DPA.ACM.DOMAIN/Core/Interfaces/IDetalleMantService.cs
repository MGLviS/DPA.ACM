using DPA.ACM.DOMAIN.Core.DTO;

namespace DPA.ACM.DOMAIN.Core.Interfaces
{
    public interface IDetalleMantService
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<ListRepMantDTO>> GetAll();
        Task<IEnumerable<ListRepMantDTO>> GetById(int id);
        Task<bool> Insert(RepMantDTO repMantDTO);
        Task<bool> Update(int id, UpdateRepMantDTO repMantDTO);
    }
}