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
    public class MecanicoRepository : IMecanicoRepository
    {
        private readonly AutoCareManagerContext _dbContext;

        public MecanicoRepository(AutoCareManagerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Mecanico>> GetAll()
        {
            return await _dbContext.Mecanico.ToListAsync();
        }

        public async Task<bool> Insert(Mecanico mecanico)
        {
            await _dbContext.Mecanico.AddAsync(mecanico);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var mecanico = await _dbContext
                .Mecanico
                .Where(x => x.MecanicoId == id).FirstOrDefaultAsync();

            if (mecanico == null)
                return false;

            _dbContext.Mecanico.Remove(mecanico);
            var rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<Mecanico> GetByName(string nomMecanico)
        {
            return await _dbContext
                .Mecanico
                .Where(x => x.Nombre == nomMecanico).FirstOrDefaultAsync();
        }

        public async Task<bool> IsTelefonoRegistered(string Telefono)
        {
            return await _dbContext
                .Mecanico
                .Where(x => x.Telefono == Telefono).AnyAsync();
        }
    }
}
