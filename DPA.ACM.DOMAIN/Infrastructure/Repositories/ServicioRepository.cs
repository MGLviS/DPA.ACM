using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPA.ACM.DOMAIN.Core.Entities;
using DPA.ACM.DOMAIN.Core.Interfaces;
using DPA.ACM.DOMAIN.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DPA.ACM.DOMAIN.Infrastructure.Repositories
{
    public class ServicioRepository : IServicioRepository
    {
        private readonly AutoCareManagerContext _dbcontext;

        public ServicioRepository(AutoCareManagerContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        // CREATE 
        public async Task<bool> InsertS(Servicio servicio)
        {
            await _dbcontext.AddAsync(servicio);
            var rows = await _dbcontext.SaveChangesAsync();
            return rows > 0;
        }

        // READ
        public async Task<IEnumerable<Servicio>> GetAll()
        {
            return await _dbcontext.Servicio.ToListAsync();
        }

        public async Task<IEnumerable<Servicio>> GetById(int id)
        {
            return await _dbcontext.Servicio.Where(x => x.ServicioId == id).ToListAsync();
        }

        //DELETE
        public async Task<bool> Delete(int id)
        {
            var servicio = await _dbcontext.Servicio.Where(x => x.ServicioId == id).FirstOrDefaultAsync();

            if (servicio == null)
                return false;

            _dbcontext.Servicio.Remove(servicio);
            var rows = await _dbcontext.SaveChangesAsync();
            return rows > 0;
        }

    }
}
