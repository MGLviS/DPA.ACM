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
    public class TallerRepository : ITallerRepository
    {
        private readonly AutoCareManagerContext _dbContext;

        public TallerRepository(AutoCareManagerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Taller>> GetAll()
        {
            return await _dbContext.Taller.ToListAsync();
        }

        public async Task<bool> Insert(Taller taller)
        {
            await _dbContext.Taller.AddAsync(taller);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var taller = await _dbContext
                .Taller
                .Where(x => x.TallerId == id).FirstOrDefaultAsync();

            if (taller == null)
                return false;

            _dbContext.Taller.Remove(taller);
            var rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<Taller> GetByName(string nomtaller)
        {
            return await _dbContext
                .Taller
                .Where(x => x.NombreTaller == nomtaller).FirstOrDefaultAsync();
        }
    }
}
