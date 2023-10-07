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
    }
}
