using DPA.ACM.DOMAIN.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA.ACM.DOMAIN.Core.Interfaces
{
    public interface ITallerService
    {
        Task<IEnumerable<TallerDTO>> ShowTalleres();
        Task<bool> RegistrarTaller(TallerRegisterDTO tallerRegisterDTO);
        Task<bool> Delete(int id);
        Task<bool> UpdateTaller(int id, TallerUpdateDTO tallerUpdateDTO);

    }
}
