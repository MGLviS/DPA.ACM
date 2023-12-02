using DPA.ACM.DOMAIN.Core.Entities;
using DPA.ACM.DOMAIN.Core.Interfaces;
using DPA.ACM.DOMAIN.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA.ACM.DOMAIN.Infrastructure.Repositories
{
    public class ProgramacionRepository : IProgramacionRepository
    {
        private readonly AutoCareManagerContext _dbContext;

        public ProgramacionRepository(AutoCareManagerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> RegProgramacion(Programacion pro)
        {
            await _dbContext.Programacion.AddAsync(pro);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<bool> Delete(int id)
        {
            var Programacion = await _dbContext.Programacion.Where(x => x.ProgramacionId == id).FirstOrDefaultAsync();
            if (Programacion == null) 
                return false;

            _dbContext.Programacion.Remove(Programacion);
            var rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<bool> Update(int id, Programacion programacion)
        {

        
            var existProgramacion = await _dbContext.Programacion.FindAsync(id);
            if (existProgramacion == null)
            {
                return false;
            }

            existProgramacion.FechaProgramacion = programacion.FechaProgramacion;
            existProgramacion.Hora = programacion.Hora;
            existProgramacion.VehiculoId = programacion.VehiculoId;
            existProgramacion.MecanicoId = programacion.MecanicoId;
            existProgramacion.Estado = programacion.Estado;

            var rows = await _dbContext.SaveChangesAsync();
            return rows > 0;

        }

        public async Task<IEnumerable<Programacion>> GetAll()
        {
            return await _dbContext.Programacion.ToListAsync();
        }
    }
}
