using DPA.ACM.DOMAIN.Core.Entities;
using DPA.ACM.DOMAIN.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA.ACM.DOMAIN.Core.Interfaces
{
    public interface IProgramacionRepository
    {
        Task<bool> RegProgramacion(Programacion pro);
        Task<bool> Delete(int id);
        Task<bool> Update(int id, Programacion programacion);
        Task<IEnumerable<Programacion>> GetAll();


    }
}
