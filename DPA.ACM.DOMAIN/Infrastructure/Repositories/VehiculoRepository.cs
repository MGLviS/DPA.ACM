using DPA.ACM.DOMAIN.Core.Entities;
using DPA.ACM.DOMAIN.Core.Interfaces;
using DPA.ACM.DOMAIN.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
namespace DPA.ACM.DOMAIN.Infrastructure.Repositories
{
    public class VehiculoRepository : IVehiculoRepository
    {
        private readonly AutoCareManagerContext _dbcontext;

        public VehiculoRepository(AutoCareManagerContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        //CREATE
        public async Task<bool> InsertV(Vehiculo vehiculo)
        {
            await _dbcontext.AddAsync(vehiculo);
            var rows = await _dbcontext.SaveChangesAsync();
            return rows > 0;
        }

        //READ

        public async Task<IEnumerable<Vehiculo>> GetAll()
        {
            return await _dbcontext.Vehiculo.ToListAsync();
        }

        public async Task<Vehiculo> GetById(int id)
        {
            return await _dbcontext.Vehiculo.Where(x => x.VehiculoId == id).FirstOrDefaultAsync();
        }

        //DELETE
        public async Task<bool> Delete(int id)
        {
            var vehiculo = await _dbcontext.Vehiculo.Where(x => x.VehiculoId == id).FirstOrDefaultAsync();
            if (vehiculo == null)
                return false;
            _dbcontext.Vehiculo.Remove(vehiculo);
            var rows = await _dbcontext.SaveChangesAsync();
            return rows > 0;
        }
    }
}

