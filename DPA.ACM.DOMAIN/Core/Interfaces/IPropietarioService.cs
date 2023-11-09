using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPA.ACM.DOMAIN.Core.DTO;
namespace DPA.ACM.DOMAIN.Core.Interfaces
{
    public interface IPropietarioService
    {
        Task<bool> RegPropietario(PropRegisterDTO propDTO);
        Task<bool> Delete(int id);
        Task<bool> Update(int id, PropietarioUpdateDTO propUpdateDTO);
        Task<PropietarioResponseDTO> SignIn(PropietarioAuthDTO propietarioAuthDTO);

    }
}
