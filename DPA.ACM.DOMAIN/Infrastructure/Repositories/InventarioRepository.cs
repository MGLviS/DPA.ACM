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
    public class InventarioRepository : IInventarioRepository
    {
        private readonly AutoCareManagerContext _dbContext;

        public InventarioRepository(AutoCareManagerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Inventario>> GetAll()
        {
            return await _dbContext.Inventario.ToListAsync();
        }

        public async Task<bool> Insert(Inventario inventario)
        {
            await _dbContext.Inventario.AddAsync(inventario);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var inventario = await _dbContext
                .Inventario
                .Where(x => x.InventarioId == id).FirstOrDefaultAsync();

            if(inventario == null) 
                return false;

            _dbContext.Inventario.Remove(inventario);
            var rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<IEnumerable<Inventario>> GetByName (string nrepuesto)
        {
         
            var busqueda = await _dbContext
                .Inventario
                .Where(x => x.Nombre.Contains(nrepuesto)).ToListAsync();

            return busqueda;
        }

        //public async Task<Inventario> GetById(int id)
        //{

        //    var busqueda = await _dbContext
        //        .Inventario
        //        .Where(x => x.InventarioId.Equals(id)).FirstOrDefaultAsync();
        //    if (busqueda == null)
        //        return null;

        //    return busqueda;
        //}

        public async Task<bool> Update(int id, Inventario inventario)
        {
            var invetarioUpdate = await _dbContext
                .Inventario
                .FindAsync(id);

            if (invetarioUpdate == null)
                return false;


            invetarioUpdate.Nombre = inventario.Nombre;
            invetarioUpdate.Descripcion = inventario.Descripcion;
            invetarioUpdate.VehiculoCompatible = inventario.VehiculoCompatible;
            invetarioUpdate.CantidadStock = inventario.CantidadStock;
            invetarioUpdate.PrecioUnitario = inventario.PrecioUnitario;

            var rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
    }
}
