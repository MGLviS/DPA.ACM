using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPA.ACM.DOMAIN.Core.Entities;
using DPA.ACM.DOMAIN.Core.Interfaces;
using DPA.ACM.DOMAIN.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DPA.ACM.DOMAIN.Infrastructure.Repositories
{
    public class DetalleMantRepository : IDetalleMantRepository
    {
        private readonly AutoCareManagerContext _dbcontext;

        public DetalleMantRepository(AutoCareManagerContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        //CREATE
        public async Task<bool> Insert(ReparacionMantenimiento repman)
        {
            await _dbcontext.AddAsync(repman);
            var rows = await _dbcontext.SaveChangesAsync();
            return rows > 0;
        }

        //READ
        public async Task<IEnumerable<ReparacionMantenimiento>> GetAll()
        {
            var repman = await _dbcontext.ReparacionMantenimiento
                .ToListAsync();
            return repman;
        }

        public async Task<IEnumerable<ReparacionMantenimiento>> GetById(int id)
        {
            var repman = await _dbcontext.ReparacionMantenimiento
                .Where(x => x.ReparacionMantenimientoId == id)
                .ToListAsync();
            return repman;
        }

        //UPDATE
        public async Task<bool> Update(int id, ReparacionMantenimiento repman)
        {
            var repmanUpdate = await _dbcontext.ReparacionMantenimiento.FindAsync(id);
            if (repmanUpdate == null)
                return false;

            repmanUpdate.Descripcion = repman.Descripcion;
            repmanUpdate.Fecha = repman.Fecha;
            repmanUpdate.ProgramacionId = repman.ProgramacionId;

            var rows = await _dbcontext.SaveChangesAsync();
            return rows > 0;
        }

        //DELETE
        public async Task<bool> Delete(int id)
        {
            var repman = await _dbcontext.ReparacionMantenimiento
                .Where(x => x.ReparacionMantenimientoId == id)
                .FirstOrDefaultAsync();

            if (repman == null) return false;
            _dbcontext.ReparacionMantenimiento.Remove(repman);
            var rows = await _dbcontext.SaveChangesAsync();
            return rows > 0;
        }
    }
}
