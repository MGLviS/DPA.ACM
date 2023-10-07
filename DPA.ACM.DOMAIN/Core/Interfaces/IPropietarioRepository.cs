using DPA.ACM.DOMAIN.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA.ACM.DOMAIN.Core.Interfaces
{
    public interface IPropietarioRepository
    {
        Task<bool> IsEmailRegistered(string correoElectronico);
        Task<bool> RegPropietario(Propetario prop);
    }
}
