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
    public class DetFacturaRepository : IDetFacturaRepository
    {
        private readonly AutoCareManagerContext _dbcontext;

        public DetFacturaRepository(AutoCareManagerContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<bool> Insert(DetallesFactura detFactura)
        {
            await _dbcontext.AddAsync(detFactura);
            var rows = await _dbcontext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<IEnumerable<DetallesFactura>> GetByID(int id)
        {
            var busqueda = await _dbcontext.DetallesFactura
                .Where(x => x.DetalleFacturaId == id)
                .Include(z => z.ReparacionMantenimiento)
                .ToListAsync();
            return busqueda;

        }

        public async Task<IEnumerable<DetallesFactura>> GetByFactura(int id)
        {
            var busqueda = await _dbcontext.DetallesFactura
                .Where(x => x.FacturaId == id)
                .Include(z => z.ReparacionMantenimiento)
                .ToListAsync();
            return busqueda;
        }
    }
}
