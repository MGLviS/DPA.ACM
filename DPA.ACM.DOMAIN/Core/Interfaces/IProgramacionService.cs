using DPA.ACM.DOMAIN.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA.ACM.DOMAIN.Core.Interfaces
{
    public interface IProgramacionService
    {
        Task<bool> RegProgramacion(PrograRegisterDTO proDTO);
        Task<bool> Delete(int id);
        Task<bool> Update(int id, PrograUpdateDTO progUpdateDTO);
        Task<IEnumerable<PrograResponseDTO>> ShowProgramacion();
    }
}
