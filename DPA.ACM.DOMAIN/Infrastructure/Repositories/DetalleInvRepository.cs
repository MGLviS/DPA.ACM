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
    public class DetalleInvRepository : IDetalleInvRepository
    {
        private readonly AutoCareManagerContext _dbcontext;

        public DetalleInvRepository(AutoCareManagerContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IEnumerable<DetalleInventario>> GetAll()
        {
            var busqueda = await _dbcontext.DetalleInventario
                .Include(z => z.Inventario)
                .ToListAsync();
            return busqueda;
        }

        public async Task<IEnumerable<DetalleInventario>> GetById(int id)
        {
            var busqueda = await _dbcontext.DetalleInventario
                .Where(x => x.DetalleInventarioId.Equals(id)).ToListAsync();

            return busqueda;
        }

        public async Task<bool> Insert(int idrepuesto, int cantidad, DetalleInventario dinventario)
        {

            var disponible = await _dbcontext.Inventario.FindAsync(idrepuesto);

            if (cantidad == 0 || disponible == null)
                return false;

            if (cantidad <= disponible.CantidadStock)
            {

                await _dbcontext.DetalleInventario.AddAsync(dinventario);
                int rows = await _dbcontext.SaveChangesAsync();
                return rows > 0;
            }

            return false;
        }

        public async Task<bool> Delete(int id)
        {
            var detalle = await _dbcontext.DetalleInventario
                .Where(x => x.DetalleInventarioId == id).FirstOrDefaultAsync();

            if (detalle == null)
                return false;
            _dbcontext.DetalleInventario.Remove(detalle);
            var rows = await _dbcontext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Update(int id, DetalleInventario dinventario)
        {
            var dinventarioUpdate = await _dbcontext
                .DetalleInventario
                .FindAsync(id);

            if (dinventarioUpdate == null)
                return false;

            dinventarioUpdate.CantidadUtilizada = dinventario.CantidadUtilizada;
            dinventarioUpdate.PrecioTotal = dinventario.PrecioTotal;

            var rows = await _dbcontext.SaveChangesAsync();
            return rows > 0;
        }


    }
}
