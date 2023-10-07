using DPA.ACM.DOMAIN.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA.ACM.DOMAIN.Core.Interfaces
{
    public interface IMecanicoRepository
    {
        Task<IEnumerable<Mecanico>> GetAll();
        Task<bool> Insert(Mecanico mecanico);
        Task<bool> Delete(int id);
        Task<Mecanico> GetByName(string nomMecanico);
    }
}
